using UnityEngine;
using Assets.Code.States;
using Assets.Code.Interfaces;

namespace Assets.Code.States {
	public class StageChoice : IState {
		private StateManager manager;
		
		public StageChoice(StateManager stateManager) {
			//初期化
			manager = stateManager;
		}
		
		public void StateUpdate() { 
			//更新処理
			if(Input.GetKeyUp(KeyCode.Return)) { // Returnキーを押すとStartSceneに遷移
				//Application.LoadLevel("Scene0");
				Debug.Log("Play State");
				manager.SwitchState(new Stage01(manager));
			}
		}
		public void Render() {
			//描画等
			if(GUI.Button(new Rect(100, 100, 100, 50), "comingsoon")) {
				Application.LoadLevel("Start");
				Time.timeScale = 1;
				manager.SwitchState(new Stage01(manager));    
			}
		}
	}
}