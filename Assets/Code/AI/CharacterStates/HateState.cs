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
			if (hate == 0 ) {
				Debug.Log ("Switch to Avoid State");
				npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Fear);
			//憎むべきプレイヤーを探す
			if (Vector3.Distance(npc.position, player.position) <= 300.0f)
			{
				Debug.Log("Switch to Chase State");
					npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.ReachPlayer);
			}
		}
		}
		
		public override void Act(Transform player, Transform npc)
		{
			destPos = player.position;
			Vector3 avoidpos = (destPos - npc.position) * -1;
			
			Quaternion targetRotation = Quaternion.LookRotation(avoidpos);
			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
			
			npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);


			float dist = Vector3.Distance(npc.position, destPos);
			if (dist <= 200.0f)
			{
				Debug.Log("Switch to Attack state");
				npc.GetComponent<NPCEnemyController>().SetTransition(Transition.ReachPlayer);
			}
			int hate = npc.GetComponent<NPCEnemyController> ().hate;

		}
	}
}
