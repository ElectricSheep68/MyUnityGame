using UnityEngine;
using System;

namespace Saiyaku{
	
	[Serializable]
	public class StateManagerController{
		
		public IStateManager Statecontroller;
		public StateManager statemanager;

		public StateManagerController(){

			statemanager = new StateManager();
		}
		
		public void SetStateManagerController(IStateManager statemanagercontroller){
			this.Statecontroller = statemanagercontroller;
		}
		
		public string GetStateName(){
			string statename = statemanager.activeState.ToString();
			return statename;
		}
		
	}
}