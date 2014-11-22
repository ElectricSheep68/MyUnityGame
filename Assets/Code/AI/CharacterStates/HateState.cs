using UnityEngine;
using System.Collections;
namespace Saiyaku {
	public class HateState : FSMState
	{
		public HateState(Transform[] wp) 
		{ 
			waypoints = wp;
			stateID = FSMStateID.Trick;
			
			curRotSpeed = 0.5f;
			curSpeed = 5.0f;
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
			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
			
			npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
			Transform turret = npc.GetComponent<NPCEnemyController>().turret;

			float dist = Vector3.Distance(npc.position, destPos);
			if (dist >3.0f) 
			{
				Quaternion turretRotation = Quaternion.LookRotation( destPos - turret.position);
				turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
			}
			if (dist <= 3.0f)
			{

				turret.rigidbody.velocity = Vector3.zero;
				//射撃
				npc.GetComponent<NPCEnemyController>().ShootBullet();
			}

		}
	}
}
