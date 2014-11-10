using UnityEngine;
using System.Collections;

public class IdolState : FSMState
{
	public IdolState(Transform[] wp) 
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
						npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.NoMind);
				}
	
				int hate = npc.GetComponent<NPCEnemyController> ().hate;
				//憎しみがたまると攻撃
				if (hate > 100) {
						Debug.Log ("Switch to hate State");
			npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Hate);
		}
		//気まぐれに待機する。
		int random = (Random.Range(0,6))
		if (random > 5) {
			Debug.Log ("Switch to loiter State");
			npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.NoMind2);
		}
	}

	public override void Act(Transform player, Transform npc)
	{
		//Find another random patrol point if the current point is reached
		//ターゲット地点に到着した場合に、パトロール地点を再度策定
		if (Vector3.Distance(npc.position, destPos) <= 100.0f)
		{
			Debug.Log("Reached to the destination point\ncalculating the next point");
			FindNextPoint();
		}
		
		//ターゲットに回転
		Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
		npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
		
		//前進
		npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
	}
}