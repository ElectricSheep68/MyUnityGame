using UnityEngine;
using Assets.Code.Interfaces;
using Assets.Code.States;

namespace Assets.Code.Interfaces
{
	public interface IState{
		void StateUpdate();

		void Render();
	}
}