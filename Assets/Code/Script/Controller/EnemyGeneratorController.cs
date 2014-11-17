using UnityEngine;
using System.Collections;

namespace Saiyaku{

//	[Serializable]
public class EnemyGeneratorController{
	//プレハブを定義
	public GameObject prefab;
	private float randum = 7f;
	private float enemySpeed = 10f;
	private float enemySpan = 10f;
	private float accum = 0;

	public IEnemyGenerator enemyGeneratorController;
		
	public EnemyGeneratorController (){
	}
		
		public void SetEnemyGeneratorController(IEnemyGenerator enemyGeneratorController) {
			this.enemyGeneratorController = enemyGeneratorController;
	}

	void EnemySpan() {
		//経過時間を保存
		accum += Time.deltaTime;

		if (accum >= enemySpan) 
		{
			return true;
			accum = 0;
		}
	}
}
}