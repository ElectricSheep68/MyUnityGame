using UnityEngine;
using Assets.Code.Interfaces;
using Assets.Code.States;

namespace Assets.Code.States{
	public class Stage01 : IState {
		private StateManager manager;
		
		public void StartScene(StateManager stateManager) {
			//初期化
			manager = stateManager;
		}
		
		public void StateUpdate() { 
			//更新処理
			if(Input.GetKeyUp(KeyCode.Return)) { // Returnキーを押すとStartSceneに遷移
				//Application.LoadLevel("Scene0");
				Debug.Log("Play State");
				manager.SwitchState(new StartScene(manager));
			}
		}
		public void Render() {
			//描画等
			if(GUI.Button(new Rect(50, 50, 50, 50), "comingsoon")) {
				Application.LoadLevel("Start");
				Time.timeScale = 1;
				manager.SwitchState(new StartScene(manager));    
			}
		}
	}
}