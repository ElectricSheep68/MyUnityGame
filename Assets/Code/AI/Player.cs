using UnityEngine;
using System.Collections;
namespace Saiyaku{
public class Player: MonoBehaviour 
	{
		public float speed = 5.0f;
		public float mass = 5.0f;
		public float force = 10.0f;
		public float playerpower = 5.0f;
		private GameObject enemy;
		//Actual speed of the vehicle 
		private float curSpeed;
		private Vector3 targetPoint;
		
		// Use this for initialization
		void Start () 
		{
			mass = 5.0f;        
			targetPoint = Vector3.zero;
		}
		// Update is called once per frame
		void Update () 
		{
			
			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 50.0f))
			{
				targetPoint = hit.point;
			}
			
			//目標点への方向ベクトル
			Vector3 dir = (targetPoint - transform.position);
			dir.Normalize();
			//目標点に到達後は停止
			if(Vector3.Distance(targetPoint, transform.position) < 2.5f)
				return;
			
			//速度をデルタタイムで標準化します
			curSpeed = speed * Time.deltaTime;
			
			//操作対象の向きを変えます（回転）
			var rot = Quaternion.LookRotation(dir);
			rot.z = 0;
			rot.x = 0;
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, 10.0f *  Time.deltaTime);
			
			//操作対象を動かします
			transform.position += transform.forward * curSpeed;

			//ぶれをなくすために完全にとめます
			rigidbody.velocity = Vector3.zero;

			//敵にぶつかったら敵をぶっ飛ばします
			}
		void OnCollisionEnter(Collision collision){
			if(collision.collider.tag == "Enemy"){
					enemy = GameObject.Find("Enemy");
					int hate = enemy.GetComponent<NPCEnemyController> ("hate")as hate;
					hate += 15;
				Debug.Log("hate"+hate);
					enemy.rigidbody.AddForce(Vector3.forward*playerpower);
				}
				//壁にぶつかったら止まります。
			if(collision.collider.tag == "Wall"){
					targetPoint = transform.position;
			}
			//災厄に触れたら大ダメージ
			if(collision.collider.tag == "Saiyaku"){

			}
	

		}
	}
}