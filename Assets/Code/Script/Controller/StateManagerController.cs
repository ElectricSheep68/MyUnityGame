using UnityEngine;
using System;

namespace Saiyaku{
	
	[Serializable]
	public class StateManagerController{
		
		public IStateManager statecontroller;
		public StateManager statemanager;

		public StateManagerController(){

			statemanager = new StateManager();
		}

		public void SetStateManagerController(IStateManager statemanagercontroller){
			this.statecontroller = statemanagercontroller;
		}
		
		public string GetStateName(){
			string statename = statemanager.activeState.ToString();
			return statename;
		}
		
	}
}