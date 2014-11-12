using UnityEngine;

namespace Saiyaku{
	public class Result : IState {
		private StateManager manager;
		
		public Result(StateManager stateManager) {
			//初期化
			manager = stateManager;
		}
		public void StateUpdate() { 
				}
			public void Render() {
			//描画等
			if(GUI.Button(new Rect(100, 100, 100, 50), "Restart")) {
				Application.LoadLevel("Start");
				Time.timeScale = 1;
				manager.SwitchState(new StartScene(manager));    
			}
		}
	}	
}