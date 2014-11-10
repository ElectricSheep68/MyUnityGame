using UnityEngine;
using System.Collections;
namespace Asset.code.AI.CharacterState {
	public class HateState : FSMState
	{
		public HateState(Transform[] wp) 
		{ 
			waypoints = wp;
			stateID = FSMStateID.Patrolling;
			
			curRotSpeed = 1.0f;
			curSpeed = 100.0f;
		}
		
		public override void Reason(Transform player, Transform npc)
		{
			int hate = npc.GetComponent<NPCEnemyController> ().hate;
			//憎しみが消えるとおびえる
			if (hate < 1) {
				Debug.Log ("Switch to Avoid State");
				npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Fear);
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
