using System;
using Character.FSMSetupData;
using Character.Teddy.TeddyFSM;

namespace Character.Teddy
{
	[Serializable]
	public class TeddyStateMachineSetup : CharacterFSMSetupBase
	{
		public StateSetupBase movingStateSetup;
		public MeleeAttackStateBaseSetup attackStateSetup;
	}
}