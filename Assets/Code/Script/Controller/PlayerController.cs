using UnityEngine;
using System;

namespace Saiyaku{

	[Serializable]
	public class PlayerController
	{
		public IPlayerCtrl playerController;
		
		public PlayerController (){
		}
		
		public void SetCameraMoverController(IPlayerCtrl playerController) {
			this.playerController = playerController;
		}
	}
}