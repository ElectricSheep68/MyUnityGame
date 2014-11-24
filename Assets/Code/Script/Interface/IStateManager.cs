using System;

namespace Saiyaku{
public interface IStateManager{

		void SwichState(IState istate);
		string FormatState();

	}
}

