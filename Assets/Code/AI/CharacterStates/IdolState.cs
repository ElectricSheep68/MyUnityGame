using UnityEngine;
using System.Collections;
namespace Saiyaku {
public class IdolState : FSMState
{
	public IdolState(Transform[] wp) 
	{ 
		waypoints = wp;
		stateID = FSMStateID.Idol;
		curRotSpeed = 1.0f;
		curSpeed = 1.0f;
	}
	
		public override void Reason(Transform player, Transform npc,Transform enemy,Transform wall)
	{
		int health = npc.GetComponent<NPCEnemyController> ().health;
		int maxHP = npc.GetComponent<NPCEnemyController> ().maxHP;
				//体力が少しでも減ったら逃げモードに
		if (health < maxHP) {
		Debug.Log ("Switch to Avoid State");
		npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.NoMind);
		}
	
		int hate = npc.GetComponent<NPCEnemyController> ().hate;
		//憎しみがたまると攻撃
		if (hate > 3) {
			Debug.Log ("Switch to hate State");
			npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Hate);
		}
		//気まぐれに動く。
			int feel = npc.GetComponent<NPCEnemyController> ().feel;
				if(feel > 5){				
					Debug.Log ("Switch to Loiter State");
					npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.NoMind2);
				}

			}

		public override void Act(Transform player, Transform npc,Transform enemy,Transform wall)
	{
		
		int feel = npc.GetComponent<NPCEnemyController> ().feel;
		feel = 0;
		npc.rigidbody.velocity = Vector3.zero;
		float accum = 0;
		accum =+ Time.deltaTime;
		if(accum > Random.Range(10,40)){
			
			feel= Random.Range (0, 6);
			accum = 0f;
	}

}
}
}
