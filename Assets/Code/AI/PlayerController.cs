using UnityEngine;
using System.Collections;
using Asset.code.AI.CharacterState;

namespace Asset.code.AI {
public class playerController: MonoBehaviour 
{
	private Transform Turret;
	private Transform bulletSpawnPoint;    
	public float speed = 20.0f;
	public float mass = 5.0f;
	public float force = 50.0f;
	public float minimumDistToAvoid = 20.0f;
	private float curSpeed;
	private Vector3 targetPoint;
	private int playerHP = 500;

	void Start () 
	{	
		Turret = gameObject.transform.GetChild(0).transform;
		bulletSpawnPoint = Turret.GetChild(0).transform;

		mass = 5.0f;        
		targetPoint = Vector3.zero;
	}
	// Update is called once per frame
	void Update () 
	{
		
		RaycastHit hit;
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100.0f))
		{
			targetPoint = hit.point;
		}
		
		//目標点への方向ベクトル
			Vector3 dir = (targetPoint - Turret.transform.position);
		dir.Normalize();
		
		//障害物の照会および回避
		AvoidObstacles(ref dir);
		
		//目標点に到達後は停止
			if(Vector3.Distance(targetPoint, Turret.transform.position) < 3.0f)
			return;
		
		//速度をデルタタイムで標準化します。
		curSpeed = speed * Time.deltaTime;
		
		//操作対象の向きを変えます（回転）
		var rot = Quaternion.LookRotation(dir);
			Turret.transform.rotation = Quaternion.Slerp(Turret.transform.rotation, rot, 5.0f *  Time.deltaTime);
		
		//操作対象を動かします
			Turret.transform.position += Turret.transform.forward * curSpeed;
	}

	void OnCollisionEnter(Collision collision)
	{
		//hpを減少させます
		if (collision.gameObject.tag == "Bullet")
		{
			playerHP -= 30;
			
			if (playerHP <= 0)
			{
				GUI.Button(new Rect(100, 100, 100, 50), "GAMROVER");

				}
			}
		}

	//障害物に対して垂直のベクトルを算出して加算して方向を修正
	public void AvoidObstacles(ref Vector3 dir)
	{
		RaycastHit hit;
		
		//Only detect layer 8 (Obstacles)
		int layerMask = 1 << 8;
		
		//障害物へセンサーを当てる。一定距離内にいるか確認
			if (Physics.Raycast(Turret.transform.position, Turret.transform.forward, out hit, minimumDistToAvoid, layerMask))
		{
			//障害物との接触点の垂直ポイントを取得
			Vector3 hitNormal = hit.normal;
			hitNormal.y = 0.0f; //Don't want to move in Y-Space
			
			//現在の方向に、垂直ポイントを加えて方向を修正
				dir = Turret.transform.forward + hitNormal * force;
		}
		
	}
}
}
