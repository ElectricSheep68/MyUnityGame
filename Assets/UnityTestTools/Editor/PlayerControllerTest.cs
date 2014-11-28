using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace Saiyaku.test
{
	[TestFixture]
	[Category ("PlayerCtrl Test")]
	public class PlayerCtrlTest
	{
		public IPlayerCtrl iplayer;
		public PlayerController player;
		
		[SetUp] public void Init()
		{
			this.iplayer = GetEffectMock ();
			this.player = GetControllerMock (iplayer);
		}
		
		[TearDown] public void Cleanup()
		{
		}
		
		[Test]
		[Category ("Click Test: W")]
		public void ClickWTest() {
			player.IsClickedW ().Returns (true);
			player.CalcAngle ();
			Assert.That (300.0f, Is.EqualTo (player.GetY()));
		}
		
		[Test]
		[Category ("Click Test: S")]
		public void ClickSTest() {
			player.IsClickedS ().Returns (true);
			player.CalcAngle ();
			Assert.That (-300.0f, Is.EqualTo (player.GetY()));
		}
		
		[Test]
		[Category ("Click Test: D")]
		public void ClickDTest() {
			
		}
		
		
		private IPlayerCtrl GetEffectMock () {
			return Substitute.For<IPlayerCtrl> ();
		}
		private PlayerController GetControllerMock(IPlayerCtrl iplayer) {
			var player = Substitute.For<PlayerController> ();
			
			player.SetPlayerController (iplayer);
			return player;
		}
	}
}