using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject explosionplefab;

	void OnCollisionEnter(Collision collision){
		if (collision.collider.tag == "Bullet") {
			Destroy(collision.collider.gameObject);
			GameObject Explosion = (GameObject)Instantiate(explosionplefab,transform.position,Quaternion.identity);


				

	}
}
}