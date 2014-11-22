using UnityEngine;
using System.Collections;
namespace Saiyaku {
public class LoiterState : FSMState
{
	public LoiterState(Transform[] wp) 
	{ 
		waypoints = wp;
		stateID = FSMStateID.Loiter;
		
		curRotSpeed = 1.0f;
		curSpeed = 5.0f;
	}
	
		public override void Reason(Transform player, Transform npc,Transform enemy,Transform wall)
	{
		int health = npc.GetComponent<NPCEnemyController> ().health;
		//体力が少しでも減ったら逃げモードに
		if (health < 100) {
			Debug.Log ("Switch to Avoid State");
			npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Fear);
		}
		
		int hate = npc.GetComponent<NPCEnemyController> ().hate;
		//憎しみがたまると攻撃
		if (hate > 100) {
			Debug.Log ("Switch to hate State");
			npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.Hate);
		}
		//気まぐれに待機する。
				int feel = npc.GetComponent<NPCEnemyController> ().feel;

				if(feel > 5){				
					Debug.Log ("Switch to idol State");
					npc.GetComponent<NPCEnemyController> ().SetTransition (Transition.NoMind);
				}
				

		}
	
		public override void Act(Transform player, Transform npc,Transform enemy,Transform wall)
	{
		int feel = npc.GetComponent<NPCEnemyController> ().feel;
			feel = 0;
		//Find another random patrol point if the current point is reached
		//ターゲット地点に到着した場合に、パトロール地点を再度策定
		if (Vector3.Distance(npc.position, destPos) <= 3.0f)
		{
			Debug.Log("Reached to the destination point\ncalculating the next point");
			FindNextPoint();
		}
		
		//ターゲットに回転
		Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
		npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
		
		//前進
		npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
		
		//とまろうかなという気を起こす
		float accum = 0;
		accum =+ Time.deltaTime;
		if(accum > Random.Range(10,40)){
			
			feel= Random.Range (0, 6);
			accum = 0f;
	}
}
}
}
	