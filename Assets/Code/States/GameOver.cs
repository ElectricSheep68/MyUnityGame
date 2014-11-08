using UnityEngine;
using Assets.Code.Interfaces;
using Assets.Code.States;

namespace Assets.Code.States{
	public class GameOver : IState {
		private StateManager manager;
		
		public GameOver(StateManager stateManager) {
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