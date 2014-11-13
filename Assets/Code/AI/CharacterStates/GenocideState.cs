using UnityEngine;
using System.Collections;
namespace Saiyaku {
	public class GenocideState : FSMState
	{
		public GenocideState(Transform[] wp) 
		{ 
			waypoints = wp;
			stateID = FSMStateID.Kill;
			
			curRotSpeed = 1.0f;
			curSpeed = 10.0f;
		}
		
		public override void Reason(Transform player, Transform npc,Transform enemy,Transform wall)
		{	
			
			float enemyDist = Vector3.Distance(npc.position,enemy.position);
			if (enemyDist <= 50.0f)
			{
				Debug.Log("Switch to Genosid state");
				npc.GetComponent<SaiyakuController>().SetTransition(Transition.Genocide);
			}
			float playerDist = Vector3.Distance(npc.position,player.position);
			if (playerDist <= 50.0f)
			{
				Debug.Log("Switch to Genosid state");
				npc.GetComponent<SaiyakuController>().SetTransition(Transition.Genocide);
			}
		}
		
		public override void Act(Transform player, Transform npc,Transform enemy,Transform wall)
		{	
			RaycastHit hit;
			
			//Only detect layer 8 (Obstacles)
			int layerMask = 1 << 8;
			if (Physics.Raycast(npc.transform.position, npc.transform.forward, out hit, 20f, layerMask))
			{
				//障害物との接触点の垂直ポイントを取得
				Vector3 hitNormal = hit.normal;
				hitNormal.y = 0.0f; //Don't want to move in Y-Space
				
				Transform turret = npc.GetComponent<SaiyakuController>().turret;
				Quaternion turretRotation = Quaternion.LookRotation(hit.normal - turret.position);
				turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
				
				//射撃
				npc.GetComponent<SaiyakuController>().ShootBullet();
				
			}
			
		}
	}
}
