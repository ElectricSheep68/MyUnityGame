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
		
		public override void Reason(Transform player, Transform npc)
		{
			float dist = Vector3.Distance(npc.position, destPos);
			if (dist <= 200.0f)
			{
				Debug.Log("Switch to Detention state");
				npc.GetComponent<SaiyakuController>().SetTransition(Transition.Detention);
			}
				
		}
		
		public override void Act(Transform player, Transform npc)
		{
			//ターゲット地点をプレーヤーポジションに設定
			destPos = player.position;
			
			//砲台は常にプレーヤーに向きます。
			Transform turret = npc.GetComponent<SaiyakuController>().turret;
			Quaternion turretRotation = Quaternion.LookRotation(destPos - turret.position);
			turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
			
			//射撃
			npc.GetComponent<SaiyakuController>().ShootBullet();
			}
			
		}
	}
