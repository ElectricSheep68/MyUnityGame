using UnityEngine;
using Assets.Code.Interfaces;
using Assets.Code.States;

namespace Assets.Code.States{
	public class Result : IState {
		private StateManager manager;
		
		public Result(StateManager stateManager) {
			//初期化
			manager = stateManager;
		}
		
		public void Render() {
			//描画等
			if(GUI.Button(new Rect(100, 100, 100, 50), "Restart")) {
				Application.LoadLevel("StartScene");
				Time.timeScale = 1;
				manager.SwitchState(new Start(manager));    
			}
		}
	}	
}