using UnityEngine;
using System.Collections;

public class AvoidState : FSMState
{
	public AvoidState(Transform[] wp) 
	{ 
		waypoints = wp;
		stateID = FSMStateID.Patrolling;
		
		curRotSpeed = 1.0f;
		curSpeed = 100.0f;
	}
	
	public override void Reason(Transform player, Transform npc)
	{
		int health = npc.GetComponent<NPCEnemyController> ().health;
		//体力が少しでも減ったら逃げモードに
		if (health < 100) {
			Debug.Log ("Switch to Avoid State");
			npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Fear);
		}
		
		int hate = npc.GetComponent<NPCEnemyController> ().hate;
		//憎しみがたまると攻撃
		if (hate > 100) {
			Debug.Log ("Switch to hate State");
			npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Hate);
		}
		//気まぐれに待機する。
		int random = (Random.Range (0, 6));
		if (random > 5) {
			Debug.Log ("Switch to hate State");
			npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.NoMind);
		}
	}
	
	public override void Act(Transform player, Transform npc)
	{
		destPos = player.position;
		int a = 0
		Avoidpos = (destPos - npc.position) * -1
		
		Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
		npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
		
		npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
	}
}

