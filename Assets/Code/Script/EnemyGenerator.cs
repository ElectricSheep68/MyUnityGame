using UnityEngine;
using System.Collections;

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
		
		//ランダムな位置を定義 この~~~;はvector3
		Vector3 randamuPos = transform.position + new Vector3(Random.Range(-randum,randum), 0, 0);//現在地から
		//Randomを使うときはランダム数値を使う前に触れ幅を見ておく。
		//Debug.Log(randamuPos);
		//プレハブを生成
		GameObject enemy = (GameObject)Instantiate(prefab, randamuPos, transform.rotation);
		//前に打ち出す 力には種類が４つあり。Impulse Forceはよく使う
		//。違いは、Forceが毎フレーム動かす(FixedUpdateとかで)、impulseが単発
		
		enemy.rigidbody.AddForce(transform.forward*enemySpeed,ForceMode.Impulse);
	}
}