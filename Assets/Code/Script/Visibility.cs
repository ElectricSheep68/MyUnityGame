using UnityEngine;
using System.Collections;

public class Visibility : MonoBehaviour {

	public GameObject bulletPrefab;
	public float speed = 5f;
	void OnTriggerStay(Collider other){
		//災厄の位置
		Vector3 saiyaku = gameObject.transform.position;
		//Debug.Log (saiyaku);
		//敵が入ってきたときだけ反応する
		if (other.tag == "Enemy") {
			//敵の位置
			Vector3 enemy = other.transform.position;
			//衝突確認
			Debug.Log ("I watch an Enemy");
			//敵のほうを向くすうちをだす
			Vector3 Direction = (enemy - saiyaku).normalized;
			//敵に向けて打つ
			GameObject Bullet = (GameObject)
				Instantiate(bulletPrefab,transform.position + new Vector3(10f,10,10f),transform.rotation);
			Bullet.rigidbody.AddForce(Direction,ForceMode.Impulse);
		}
		}
	
}
