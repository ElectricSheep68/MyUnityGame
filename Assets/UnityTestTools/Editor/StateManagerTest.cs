using NUnit.Framework;
using System;
using NSubstitute;

namespace Saiyaku.Test{
	
	[TestFixture]
	[Category("StateManager Test")]
	
	public class StateManagerTest{
		
		public StateManagerController istatemanager;
		public StateManagerController statemanagercontrollre;
		public StateManager statemanager;
		
		[SetUp] public void Init(){
			this.istatemanager = GetStateManagerMock();
			this.statemanagercontrollre = GetStateControllerMock(istatemanager);
			statemanager = new StateManager();
			this.statemanagercontrollre.Statecontroller.FormatState().Returns("StartState");
		}
		
		[TearDown] public void Cleanup(){
		}
		
		[Test]
		[Category("StateName Get Test")]
		public void StateNameFormatTest(){
			string statename = istatemanager.FormatState();
			Assert.That("Start",Is.EqualTo(statename));
		}
		[Test]
		[Category("StateName Active State Get Test")]
		public void StateNameActiveStateGetTest(){
			string actstate = statemanagercontrollre.statemanager.SwichState(new StartState(statemanager));
			Assert.That("Saiyaku.Start",Is.EqualTo(actstate));
		}
		[Test]
		[Category("StateName StartState Get Test")]
		public void StateNameGameBeginStateGetTest(){
			string actstate = statemanagercontrollre.statemanager.SwichState(new StartState(this.statemanager));
			Assert.That("Saiyaku.Start",Is.EqualTo(actstate));
		}
		[Test]
		[Category("StateName StageChoice Get Test")]
		public void StateNameMenuStateGetTest(){
			string actstate = statemanagercontrollre.statemanager.SwichState(new StageChoice(this.statemanager));
			Assert.That("Saiyaku.StageChoice",Is.EqualTo(actstate));
		}
		[Test]
		[Category("StateName Stage01 Get Test")]
		public void StateNameSelectStateGetTest(){
			string actstatename = statemanagercontrollre.statemanager.SwichState(new Stage01(statemanager));
			Assert.That("Saiyaku.Stage01",Is.EqualTo(actstatename));
		}
		}
		[Test]
		[Category("StateName ResultState Get Test")]
		public void StateNameResultStateGetTest(){
			string actstate = statemanagercontrollre.statemanager.SwichState(new Result(statemanager));
			Assert.That("Saiyaku.Result",Is.EqualTo(actstate));
		}
		
		private IStateManagerController GetStateManagerMock(){
			return Substitute.For<IStateManager>();
		}
		
		private StateManagerController GetStateControllerMock(IStateManager istatemanager){
			var statemanagercontrollre = Substitute.For<StateManagerController>();
			statemanagercontrollre.SetStateManagerController(istatemanager);
			return statemanagercontrollre;
		}
	}