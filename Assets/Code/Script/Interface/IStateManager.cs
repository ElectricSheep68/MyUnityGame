using System;

namespace Saiyaku{
public interface IStateManager{

		string SwitchState(IState istate);
		string FormatState();

	}
}

