using UnityEngine;
using System.Collections;
namespace Assets.Code.Script{
public class EnemyGenerator : MonoBehaviour {
	//プレハブを定義
	public GameObject prefab;
	public float randum = 7f;
	public float enemySpeed = 10f;
	public float enemySpan = 10f;
	float accum = 0;
	
	void Update() {
		//経過時間を保存
		accum += Time.deltaTime;

		if (accum >= enemySpan) 
		{
			Generate ();
			accum = 0;
		}
	}
	
	
	//敵を生成する関数を新しく作る
	void Generate()
	{
		Vector3 randamuPos = transform.position + new Vector3(Random.Range(-randum,randum), 0, 0);//現在地から

		GameObject enemy = (GameObject)Instantiate(prefab, randamuPos, transform.rotation);
		enemy.rigidbody.AddForce(transform.forward*enemySpeed,ForceMode.Impulse);
	}
}
}