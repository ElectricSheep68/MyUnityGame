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
		public virtual Boolean IsClickedW(){
			if (Input.GetKey(KeyCode.W))
			{
				return true;
			}
			return false;
		}
		public virtual Boolean IsClickedS(){
		 if (Input.GetKey(KeyCode.S))
			{
				return true;
			}
			return false;

		}
		public virtual Boolean IsClickedA(){
			
			if (Input.GetKey(KeyCode.A))
			{
				return true;
			}
			return false;
		}
		public virtual Boolean IsClickedD(){
		 if (Input.GetKey(KeyCode.D))
			{
				return true;
			}
			return false;
		}
	}
}