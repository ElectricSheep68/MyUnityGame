using UnityEngine;

namespace Saiyaku
{
	public interface IState{
		void StateUpdate();
		void Render();
	}
}