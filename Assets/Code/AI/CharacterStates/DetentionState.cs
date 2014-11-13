using UnityEngine;
using System.Collections;
namespace Saiyaku {
	public class DetentionState : FSMState
	{
		public DetentionState(Transform[] wp) 
		{ 
			waypoints = wp;
			stateID = FSMStateID.Stop;
			
			curRotSpeed = 1.0f;
			curSpeed = 10.0f;
		}
		
		public override void Reason(Transform player, Transform npc,Transform wall)
		{
			float dist = Vector3.Distance(npc.position, destPos);
			if (dist <= 200.0f)
			{
				Debug.Log("Switch to Genosid state");
				npc.GetComponent<SaiyakuController>().SetTransition(Transition.Genocide);
			}
		}
		
		public override void Act(Transform player, Transform npc,Transform wall)
		{	
			RaycastHit hit;
			
			//Only detect layer 8 (Obstacles)
			int layerMask = 1 << 8;
			if (Physics.Raycast(npc.transform.position, npc.transform.forward, out hit, 20f, layerMask))
			{
				//障害物との接触点の垂直ポイントを取得
				Vector3 hitNormal = hit.normal;
				hitNormal.y = 0.0f; //Don't want to move in Y-Space

				//砲台は常にプレーヤーに向きます。
				Transform turret = npc.GetComponent<NPCEnemyController>().turret;
				Quaternion turretRotation = Quaternion.LookRotation(hit.normal - turret.position);
				turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
				
				//射撃
				npc.GetComponent<SaiyakuController>().ShootBullet();

			}
			
			destPos = player.position;
			Vector3 avoidpos = (destPos - npc.position) * -1;
			
			Quaternion targetRotation = Quaternion.LookRotation(avoidpos);
			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
			
			npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
			
			
			float dist = Vector3.Distance(npc.position, destPos);
			if (dist <= 5.0f)
			{
				//砲台は常にプレーヤーに向きます。
				Transform turret = npc.GetComponent<NPCEnemyController>().turret;
				Quaternion turretRotation = Quaternion.LookRotation(destPos - turret.position);
				turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
				
				//射撃
				npc.GetComponent<NPCEnemyController>().ShootBullet();
			}
			
		}
	}
}
