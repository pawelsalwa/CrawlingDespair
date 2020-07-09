using System;
using Character.FSMSetupData;

namespace Character.Teddy
{
	[Serializable]
	public class TeddyStateMachineSetup : CharacterFSMSetupBase
	{
		public StateDataBase MovingStateData;
	}
}