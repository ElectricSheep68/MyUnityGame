using UnityEngine;
using System.Collections;
namespace Saiyaku{
public class EnemyGenerator : MonoBehaviour,IEnemyGenerator {
	//プレハブを定義
		public EnemyGeneratorController controller;
		
	public void OnEnable() {
			controller.SetEnemyGeneratorController (this);
		}
	void Update() {
			Generate ();
	}
	
	
	//敵を生成する関数を新しく作る
		void Generate()
		{
			Vector3 GeneratePos = transform.position;
			GameObject enemy = (GameObject)Instantiate(prefab, GeneratePos, transform.rotation);
			enemy.rigidbody.AddForce(transform.forward*enemySpeed,ForceMode.Impulse);
		}
}
}