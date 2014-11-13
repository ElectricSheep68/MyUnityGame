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
			GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
			playerTransform = objPlayer.transform;
			
			if (!playerTransform)
				print("プレーヤーが存在しません。タグ 'Player'　を追加してください。");
			

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
			CurrentState.Reason(playerTransform, transform);
			CurrentState.Act(playerTransform, transform);
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
			
			IdolState Idol = new IdolState(waypoints);
			Idol.AddTransition(Transition.NoMind, FSMStateID.Idol);
			Idol.AddTransition(Transition.Fear, FSMStateID.Avoid);
			Idol.AddTransition(Transition.NoHealth, FSMStateID.Dead);
			Idol.AddTransition(Transition.Hate, FSMStateID.Trick);
			
			LoiterState Loiter = new LoiterState(waypoints);
			Loiter.AddTransition(Transition.NoMind2, FSMStateID.Loiter);
			Loiter.AddTransition(Transition.Fear, FSMStateID.Avoid);
			Loiter.AddTransition(Transition.NoHealth, FSMStateID.Dead);
			Loiter.AddTransition(Transition.Hate, FSMStateID.Trick);
			
			AvoidState Avoid = new AvoidState(waypoints);
			Avoid.AddTransition(Transition.Fear, FSMStateID.Avoid);
			Avoid.AddTransition(Transition.NoMind, FSMStateID.Idol);
			Avoid.AddTransition(Transition.Hate, FSMStateID.Trick);
			Avoid.AddTransition(Transition.NoHealth, FSMStateID.Dead);
			
			HateState Hate = new HateState(waypoints);
			Hate.AddTransition(Transition.Hate, FSMStateID.Trick);
			Hate.AddTransition(Transition.Fear, FSMStateID.Avoid);
			Hate.AddTransition(Transition.NoHealth, FSMStateID.Dead);
			
			DeadState dead = new DeadState();
			dead.AddTransition(Transition.NoHealth, FSMStateID.Dead);
			
			AddFSMState(Idol);
			AddFSMState(Avoid);
			AddFSMState(Hate);
			AddFSMState(dead);
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