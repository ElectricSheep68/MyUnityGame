using UnityEngine;
using System;
namespace Saiyaku{
public class EnemyGenerator : MonoBehaviour,IEnemyGenerator {
	
	public EnemyGeneratorController controller;
	public GameObject prefab;
	
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
}
}
