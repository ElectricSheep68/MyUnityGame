using UnityEngine;
using System.Collections;

public class NPCEnemyController : AdvancedFSM //継承してる
{
	public GameObject Bullet;
	private int health;
	
	//NPC FSMの初期化
	protected override void Initialize()
	{
		health = 100;
		
		elapsedTime = 0.0f;
		shootRate = 2.0f;
		
		GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
		playerTransform = objPlayer.transform;
		
		if (!playerTransform)
			print("プレーヤーが存在しません。タグ 'Player'　を追加してください。");
		
		//　戦車の砲台を取得
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
		
		PatrolState patrol = new PatrolState(waypoints);
		patrol.AddTransition(Transition.SawPlayer, FSMStateID.Chasing);
		patrol.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		ChaseState chase = new ChaseState(waypoints);
		chase.AddTransition(Transition.LostPlayer, FSMStateID.Patrolling);
		chase.AddTransition(Transition.ReachPlayer, FSMStateID.Attacking);
		chase.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		AttackState attack = new AttackState(waypoints);
		attack.AddTransition(Transition.LostPlayer, FSMStateID.Patrolling);
		attack.AddTransition(Transition.SawPlayer, FSMStateID.Chasing);
		attack.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		DeadState dead = new DeadState();
		dead.AddTransition(Transition.NoHealth, FSMStateID.Dead);
		
		AddFSMState(patrol);
		AddFSMState(chase);
		AddFSMState(attack);
		AddFSMState(dead);
	}
	
	//　弾丸の衝突判定
	void OnCollisionEnter(Collision collision)
	{
		//hpを減少させます
		if (collision.gameObject.tag == "Bullet")
		{
			health -= 50;
			
			if (health <= 0)
			{
				Debug.Log("Switch to Dead State");
				SetTransition(Transition.NoHealth);
				Explode();
			}
		}
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