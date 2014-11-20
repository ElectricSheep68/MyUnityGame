using UnityEngine;
using System;
namespace Saiyaku{
public class EnemyGenerator : MonoBehaviour,IEnemyGenerator {
	
	public EnemyGeneratorController controller;
		
	public void OnEnable() {
			controller.SetEnemyGeneratorController (this);
		}
	void Update() {
		controller.EnemySpan();
		Generate ();

	}
		public void Generate()
		{
				Instantiate(prefab, transform.position, transform.rotation);
			}
		public GameObject prefab(GameObject obj){
			return this.prefab = obj;
		}
}
}
