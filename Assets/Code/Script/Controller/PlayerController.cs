using UnityEngine;
using System;

namespace Saiyaku{

	[Serializable]
	public class PlayerController
	{
		private float x = 0.0f;
		private float y = 0.0f;
		private float z = 0.0f;
		
		public Vector3 angle = Vector3.zero;
		public Vector3 cPosition = Vector3.zero;

		private float rotSpeed;

		public IPlayerCtrl playerController;
		
		public PlayerController (){
		}
		
		public void SetPlayerController(IPlayerCtrl playerController) {
			this.playerController = playerController;
		}

		public void CalcAngle() {
			CalcAngleY ();
			SetAngle ();
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
		private void CalcAngleY() {
			
			if (IsClickedW()) {
				y += 300f;
			}
			if (IsClickedS ()) {
				y -= 300f;
			}
		}

		public Vector3 GetAngle() {
			return this.angle;
		}
		
		public void SetAngle() {
			this.angle.x = x;
			this.angle.y = y;
			this.angle.z = z;
		}
		
		public float GetY() {
			return y;
		}
		
		public float GetX() {
			return x;
		}
	}
}