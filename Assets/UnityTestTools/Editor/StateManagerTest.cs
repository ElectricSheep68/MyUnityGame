using NUnit.Framework;
using System;
using NSubstitute;

namespace Saiyaku.Test{
	
	[TestFixture]
	[Category("StateManager Test")]
	
	public class StateManagerTest{
		
		public IStateManager istatemanager;
		public StateManagerController statemanagercontrollre;
		public StateManager statemanager;
		
		[SetUp] public void Init(){
			this.istatemanager = GetStateManagerMock();
			this.statemanagercontrollre = GetStateControllerMock(istatemanager);
			statemanager = new StateManager();
			this.istatemanager.FormatState().Returns("StartState");
		}
		
		[TearDown] public void Cleanup(){
		}
		
		[Test]
		[Category("StateName Get Test")]
		public void StateNameFormatTest(){
			string statename = istatemanager.FormatState();
			Assert.That("StartState",Is.EqualTo(statename));
		}
		[Test]
		[Category("StateName Active State Get Test")]
		public void StateNameActiveStateGetTest(){
			string actstate = statemanagercontrollre.statemanager.SwitchState(new StartScene(statemanager));
			Assert.That("Saiyaku.StartScene",Is.EqualTo(actstate));
		}
		[Test]
		[Category("StateName Start Get Test")]
		public void StateNameGameBeginStateGetTest(){
			string actstate = statemanagercontrollre.statemanager.SwitchState(new StartScene(this.statemanager));
			Assert.That("Saiyaku.StartScene",Is.EqualTo(actstate));
		}
		[Test]
		[Category("StateName StageChoice Get Test")]
		public void StateNameStageChoiceStateGetTest(){
			string actstate = statemanagercontrollre.statemanager.SwitchState(new StageChoice(this.statemanager));
			Assert.That("Saiyaku.StageChoice",Is.EqualTo(actstate));
		}
		[Test]
		[Category("StateName Stage01 Get Test")]
		public void StateNameStage01GetTest(){
			string actstatename = statemanagercontrollre.statemanager.SwitchState(new Stage01(statemanager));
			Assert.That("Saiyaku.Stage01",Is.EqualTo(actstatename));
		}
		[Test]
		[Category("StateName Result Get Test")]
		public void StateNameResultStateGetTest(){
		string actstate = statemanagercontrollre.statemanager.SwitchState(new Result(statemanager));
			Assert.That("Saiyaku.Result",Is.EqualTo(actstate));
		}
		
		private IStateManager GetStateManagerMock(){
			return Substitute.For<IStateManager>();
		}
		
		private StateManagerController GetStateControllerMock(IStateManager istatemanager){
			var statemanagercontrollre = Substitute.For<StateManagerController>();
			statemanagercontrollre.SetStateManagerController(istatemanager);
			return statemanagercontrollre;
		}
	}
}