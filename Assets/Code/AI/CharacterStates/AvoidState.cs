using UnityEngine;
using System.Collections;
namespace Asset.code.AI.CharacterState {
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
			//体力回復で待機
		if (health >= 100) {
				Debug.Log ("Switch to Idol State");
				npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.NoMind);
		}
		
		int hate = npc.GetComponent<NPCEnemyController> ().hate;
		//憎しみがたまると攻撃
		if (hate > 100) {
			Debug.Log ("Switch to hate State");
			npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Hate);
		}
	}
	
	public override void Act(Transform player, Transform npc)
	{
		destPos = player.position;
		Vector3 avoidpos = (destPos - npc.position) * -1;
		
		Quaternion targetRotation = Quaternion.LookRotation(avoidpos);
		npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
		
		npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
	}
}
}
