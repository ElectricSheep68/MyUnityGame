using UnityEngine;

namespace Saiyaku
{
	public interface IState{
		void StateUpdate();
		void SwichState(IState istate);
		void Render();
	}
}