using UnityEngine;
using System.Collections;
namespace Saiyaku {
public class DeadState : FSMState
{
	public DeadState() 
	{
		stateID = FSMStateID.Dead;
	}
	
		public override void Reason(Transform player, Transform npc,Transform enemy,Transform wall)
	{
		
	}
	
		public override void Act(Transform player, Transform npc,Transform enemy,Transform wall)
	{
		
	}
}
}