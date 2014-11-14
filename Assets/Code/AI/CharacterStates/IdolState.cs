using UnityEngine;
using System.Collections;
namespace Saiyaku {
public class IdolState : FSMState
{
	public IdolState(Transform[] wp) 
	{ 
		waypoints = wp;
		stateID = FSMStateID.Patrolling;
		curRotSpeed = 1.0f;
		curSpeed = 1.0f;
	}
	
		public override void Reason(Transform player, Transform npc,Transform enemy,Transform wall)
	{
		int health = npc.GetComponent<NPCEnemyController> ().health;
				//体力が少しでも減ったら逃げモードに
		if (health < 100) {
		Debug.Log ("Switch to Avoid State");
		npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.NoMind);
		}
	
		int hate = npc.GetComponent<NPCEnemyController> ().hate;
		//憎しみがたまると攻撃
		if (hate > 10) {
			Debug.Log ("Switch to hate State");
			npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Hate);
		}
		//気まぐれに動く。
			float accum =+ Time.deltaTime;
			int feel;
			if(accum > Random.Range(10,40)){

				feel= Random.Range (0, 6);
				if(feel > 5){				
					Debug.Log ("Switch to Loiter State");
					npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.NoMind2);

				}
				accum = 0f;
			}
	}

		public override void Act(Transform player, Transform npc,Transform enemy,Transform wall)
	{
			npc.rigidbody.velocity = Vector3.zero;


}
}
}