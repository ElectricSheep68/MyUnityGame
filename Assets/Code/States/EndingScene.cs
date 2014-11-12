using UnityEngine;

namespace Saiyaku{
	public class EndingScene : IState {
		private StateManager manager;
		
		public EndingScene(StateManager stateManager) {
			//初期化
			manager = stateManager;
		}
		public void StateUpdate() {
				}
			public void Render() {
			//描画等
			if(GUI.Button(new Rect(100, 100, 100, 50), "Replay?")) {
				Application.LoadLevel("Stage01");
				Time.timeScale = 1;
				manager.SwitchState(new Stage01(manager));    
			}
		}
	}	
	}