using UnityEngine;
using System.Collections;
namespace Saiyaku{
	public class Saiyaku2 : MonoBehaviour {
		public GameObject Bullet;
		float accum = 0;
		// Update is called once per frame
		void Update(){
			// accum = Time.deltaTime + accum
			accum += Time.deltaTime;

			float bulletSpan = 3f;

			GameObject player =  GameObject.FindWithTag("Player");
			GameObject enemy =  GameObject.FindWithTag("Enemy");
			GameObject saiyaku = this.gameObject;

			Vector3 enemyV = enemy.transform.position;
			Vector3 playerV = player.transform.position;
			Vector3 saiyakuV = saiyaku.transform.position;

			float enemyDist = Vector3.Distance(enemyV,saiyakuV);
			float playerDist = Vector3.Distance(playerV,saiyakuV);

			Transform turret = gameObject.transform.GetChild(0).transform;
			Transform bulletSpawnPoint = turret.GetChild(0).transform;

			float curRotSpeed = 10f;

			Vector3 avoidposP = (playerV - saiyakuV) * -1f;
			Quaternion targetRotationP = Quaternion.LookRotation(avoidposP);
			saiyaku.transform.rotation = Quaternion.Slerp(saiyaku.transform.rotation, targetRotationP, Time.deltaTime * curRotSpeed);

			
			Vector3 avoidposE = (enemyV - saiyakuV) * -1;
			
			Quaternion targetRotationE = Quaternion.LookRotation(avoidposE);
			saiyaku.transform.rotation = Quaternion.Slerp(saiyaku.transform.rotation, targetRotationE, Time.deltaTime * curRotSpeed);

			Debug.Log ("enemy"+enemyDist);
			//Debug.Log ("player"+playerDist);
			Debug.Log ("Enemy near" + (enemyDist < playerDist));
			if (enemyDist <= 5.0f && enemyDist < playerDist)
			{
				Quaternion turretRotation = Quaternion.LookRotation(playerV - turret.transform.position);
				turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);

				Debug.Log("accum:"+accum);
				Debug.Log("bulletSpan:"+bulletSpan);
				if(accum > bulletSpan){	
					Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
					accum = 0f;
				}
			}
			else if (playerDist <= 5.0f && enemyDist > playerDist)
			{
				Quaternion turretRotation = Quaternion.LookRotation(enemyV - turret.transform.position);
				turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
				if(accum > bulletSpan){	
					Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
					accum = 0f;
				}
			}
			else if (playerDist >= 5.0f && enemyDist >= 5f){
				
				saiyaku.rigidbody.velocity = Vector3.zero;
			}

		}
	}
}