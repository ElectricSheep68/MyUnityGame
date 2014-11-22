using UnityEngine;
using System.Collections;
namespace Saiyaku {
	public class GenocideState : FSMState
	{
		public GenocideState(Transform[] wp) 
		{ 
			waypoints = wp;
			stateID = FSMStateID.Kill;
			
			curRotSpeed = 10.0f;
		}
		
		public override void Reason(Transform player, Transform npc,Transform enemy,Transform wall)
		{	
			
			float wallDist = Vector3.Distance(npc.position,enemy.position);
			if (wallDist <0f)
			{
				Debug.Log("Switch to Detention state");
				npc.GetComponent<SaiyakuController>().SetTransition(Transition.Detention);
			}
		}
		
		public override void Act(Transform player, Transform npc,Transform enemy,Transform wall)
		{	
		
			Vector3 posP = (player.position - npc.position) * -1;
			
			Quaternion targetRotationP = Quaternion.LookRotation(posP);
			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotationP, Time.deltaTime * curRotSpeed);
			
			npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);

			float distP = Vector3.Distance(npc.position, player.position);

			Vector3 posE = (enemy.position - npc.position) * -1;
			
			Quaternion targetRotationE = Quaternion.LookRotation(posE);
			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotationE, Time.deltaTime * curRotSpeed);
			
			npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);

			float distE = Vector3.Distance(npc.position, player.position);

			if (distE <= 4.0f && distE < distP)
			{
				Debug.Log("kill Enemy");
				Transform turret = npc.GetComponent<SaiyakuController>().turret;
				Quaternion turretRotation = Quaternion.LookRotation(enemy.position - turret.position);
				turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
				
				//射撃
				npc.GetComponent<SaiyakuController>().ShootBullet();
			}
			if (distP <= 4.0f && distE > distP)
			{
				Debug.Log ("kill Player");
				Transform turret = npc.GetComponent<SaiyakuController>().turret;
				Quaternion turretRotation = Quaternion.LookRotation(player.position - turret.position);
				turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
				
				//射撃
				npc.GetComponent<SaiyakuController>().ShootBullet();
			}
			if (distP >= 4.0f && distE >= 4f){

				npc.rigidbody.velocity = Vector3.zero;

			}
		}
	}
}
