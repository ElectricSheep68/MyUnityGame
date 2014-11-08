using UnityEngine;
using Assets.Code.Interfaces;
using Assets.Code.States;

namespace Assets.Code.States{
	public class Stage01 : IState {
		private StateManager manager;
		
		public Stage01(StateManager stateManager) {
			//初期化
			manager = stateManager;
		}
		
		public void Render() {
			//描画等
			if(GUI.Button(new Rect(100, 100, 100, 50), "comingsoon")) {
				Application.LoadLevel("Stage01");
				Time.timeScale = 1;
				manager.SwitchState(new Stage01(manager));    
			}
		}
	}	
}