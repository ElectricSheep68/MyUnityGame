using UnityEngine;
using System;
namespace Saiyaku{
public class EnemyGenerator : MonoBehaviour,IEnemyGenerator {
	//プレハブを定義
		public EnemyGeneratorController controller;
		
	public void OnEnable() {
			controller.SetEnemyGeneratorController (this);
		}
	void Update() {
		controller.Generate ();
	}
}
}
