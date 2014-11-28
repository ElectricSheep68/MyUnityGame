using UnityEngine;
using System.Collections;
namespace Saiyaku {
	public class HateState : FSMState
	{
		public HateState(Transform[] wp) 
		{ 
			waypoints = wp;
			stateID = FSMStateID.Trick;
			
			curRotSpeed = 5f;
			curSpeed = 10.0f;
		}
		
		public override void Reason(Transform player, Transform npc,Transform enemy,Transform wall)
		{
			int hate = npc.GetComponent<NPCEnemyController> ().hate;
			//憎しみが消えるとおびえる
			if (hate == 0 ) {
				Debug.Log ("Switch to Avoid State");
				npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Fear);
		
		}
		}
		
		public override void Act(Transform player, Transform npc,Transform enemy,Transform wall)
		{

			destPos = player.position;
			Vector3 avoidpos = (destPos - npc.position);
			
			Quaternion targetRotation = Quaternion.LookRotation(avoidpos);
			targetRotation.x = 0;
			targetRotation.z = 0;

			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

			float dist = Vector3.Distance(npc.position, destPos);
			if(dist<1f) 
			{
				player.rigidbody.AddForce(avoidpos.normalized,ForceMode.Impulse);
			}

		}
	}
}
