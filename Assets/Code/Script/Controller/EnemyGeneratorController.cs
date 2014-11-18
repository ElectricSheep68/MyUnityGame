using UnityEngine;
using System;

namespace Saiyaku{

[Serializable]
public class EnemyGeneratorController{
	public GameObject prefav;
	private float randum = 7f;
	private float enemySpeed = 10f;
	private float enemySpan = 100f;
	private float accum = 0;	
	public IEnemyGenerator enemyGeneratorController;
		
	public EnemyGeneratorController (){
	}
		
		public void SetEnemyGeneratorController(IEnemyGenerator enemyGeneratorController) {
			this.enemyGeneratorController = enemyGeneratorController;
	}

		public void AccumAdd() {
			accum = 0;
			accum += Time.deltaTime;
		}

		private bool EnemySpan() {
			AccumAdd ();

			if (accum >= enemySpan) 
			{
				return true;
			}
				return false;
		}

		public void Generate()
		{
			if(EnemySpan()){
				Instantiate(prefab, transform.position, transform.rotation);
			}
		}
}
}