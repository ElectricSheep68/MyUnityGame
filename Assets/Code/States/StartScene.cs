using UnityEngine;

namespace Saiyaku{
	public class StartScene : IState {
		private StateManager manager;
		
		public StartScene(StateManager stateManager) {
			//初期化
			manager = stateManager;
			Time.timeScale = 0;
		}
		public void StateUpdate(){

		}
		public void Render() {
			//描画等
			if(GUI.Button(new Rect(110, 100, 50, 50), "Stat")) {
				Application.LoadLevel("StageChoice");
				Time.timeScale = 1;
				manager.SwitchState(new StageChoice(manager));    
			}
			
		}
	}
}