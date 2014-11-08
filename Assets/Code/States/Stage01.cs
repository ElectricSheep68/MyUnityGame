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
		public void StateUpdate() {
				}
			public void Render() {
			//描画等
			if(GUI.Button(new Rect(50, 50, 100, 50), "TestGameOver")) {
				Application.LoadLevel("GameOver");
				Time.timeScale = 1;
				manager.SwitchState(new GameOver(manager));    
			}
			if(GUI.Button(new Rect(50, 110, 100, 50), "TestResult")) {
				Application.LoadLevel("Result");
				Time.timeScale = 1;
				manager.SwitchState(new Result(manager));    
		}
	}		
	}
}