using UnityEngine;
using System;

namespace Saiyaku{

	[Serializable]
	public class PlayerController
	{
		private float rotSpeed;

		public IPlayerCtrl playerController;
		
		public PlayerController (){
		}
		
		public void SetPlayerController(IPlayerCtrl playerController) {
			this.playerController = playerController;
		}

		public void setRotSpeed(float rotSpeed) {
			this.rotSpeed = rotSpeed;
		}

		public float getRotSpeed() {
			return rotSpeed;
		}

	}
}