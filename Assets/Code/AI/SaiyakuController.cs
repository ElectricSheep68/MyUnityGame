using UnityEngine;
using System.Collections;
namespace Saiyaku{
	public class SaiyakuController : AdvancedFSM 
	{
		public GameObject Bullet;
		//NPC FSMの初期化
		protected override void Initialize()
		{
			elapsedTime = 0.0f;
			shootRate = 2.0f;
			GameObject objPlayer = GameObject.FindGameObjectWithTag("player");
			playerTransform = objPlayer.transform;

			GameObject objEnemy = GameObject.FindGameObjectWithTag("Enemy");
			enemyTransform = objEnemy.transform;

			GameObject objWall = GameObject.FindGameObjectWithTag("Wall");
			wallTransform = objWall.transform;

			turret = gameObject.transform.GetChild(0).transform;
			bulletSpawnPoint = turret.GetChild(0).transform;
			
			// FSMを構築
			ConstructFSM();
		}
		
		protected override void FSMUpdate()
		{
			//　ヘルスチェック
			elapsedTime += Time.deltaTime;
		}
		
		protected override void FSMFixedUpdate()
		{
			CurrentState.Reason(playerTransform, transform,enemyTransform,wallTransform);
			CurrentState.Act(playerTransform, transform,enemyTransform,wallTransform);
		}
		
		public void SetTransition(Transition t) 
		{ 
			PerformTransition(t); 
		}
		
		private void ConstructFSM()
		{
			//ポイントのリスト
			pointList = GameObject.FindGameObjectsWithTag("WandarPoint");
			
			Transform[] waypoints = new Transform[pointList.Length];
			int i = 0;
			foreach(GameObject obj in pointList)
			{
				waypoints[i] = obj.transform;
				i++;
			}
			
			GenocideState Genocide = new GenocideState(waypoints);
			Genocide.AddTransition(Transition.Genocide, FSMStateID.Kill);
			Genocide.AddTransition(Transition.Detention, FSMStateID.Stop);
			Genocide.AddTransition(Transition.NoMind, FSMStateID.Idol);
			DetentionState Detention = new DetentionState(waypoints);
			Detention.AddTransition(Transition.Detention, FSMStateID.Stop);
			Detention.AddTransition(Transition.Genocide, FSMStateID.Kill);
			Detention.AddTransition(Transition.NoMind, FSMStateID.Idol);

			IdolState Idol = new IdolState(waypoints);
			Idol.AddTransition(Transition.NoMind, FSMStateID.Idol);
			Idol.AddTransition(Transition.Genocide, FSMStateID.Kill);
			Idol.AddTransition(Transition.Detention, FSMStateID.Stop);

			AddFSMState(Genocide);
			AddFSMState(Idol);
			AddFSMState(Detention);
		}

		protected void Explode()
		{
			float rndX = Random.Range(10.0f, 30.0f);
			float rndZ = Random.Range(10.0f, 30.0f);
			for (int i = 0; i < 3; i++)
			{
				rigidbody.AddExplosionForce(10000.0f, transform.position - new Vector3(rndX, 10.0f, rndZ), 40.0f, 10.0f);
				rigidbody.velocity = transform.TransformDirection(new Vector3(rndX, 20.0f, rndZ));
			}
			
			Destroy(gameObject, 1.5f);
		}
		
		public void ShootBullet()
		{
			if (elapsedTime >= shootRate)
			{
				Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
				elapsedTime = 0.0f;
			}
		}
	}
}