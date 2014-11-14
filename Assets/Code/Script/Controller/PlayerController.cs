using UnityEngine;
using System;

namespace Saiyaku{

	[Serializable]
	public class PlayerController
	{
		public IPlayerCtrl playerController;
		
		public PlayerController (){
		}
		
		public void SetPlayerController(IPlayerCtrl playerController) {
			this.playerController = playerController;
		}
	}
}