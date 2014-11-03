using UnityEngine;
using Assets.Code.Interfaces;
using Assets.Code.States;


namespace Assets.Code.States{
	public class StartScene : IState {
		private StateManager manager;
		
		public StartScene(StateManager stateManager) {
			//初期化
			manager = stateManager;
			Time.timeScale = 0;
		}
		
		public void StateUpdate() {
			//更新処理
			if(Input.GetKeyUp(KeyCode.Return)) { // Returnキーを押すとStageChoisに遷移
				Application.LoadLevel("StageChoice");
				Debug.Log("Start");
				manager.SwitchState(new StageChoice(manager));
			}
		}
		
		// Playボタンを生成して、ボタンが押されたときに、Stage1に遷移
		public void Render() {
			//描画等
			if(GUI.Button(new Rect(50, 50, 50, 50), "Stat")) {
				Application.LoadLevel("StageChoice");
				Time.timeScale = 1;
				manager.SwitchState(new StageChoice(manager));    
			}
		}
	}
}