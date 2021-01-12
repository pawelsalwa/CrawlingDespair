using System;
using Character.FSMSetupData;
using Character.Teddy.TeddyFSM;
using UnityEngine.Serialization;

namespace Character.Teddy
{
	[Serializable]
	public class TeddyStateMachineSetup : CharacterFSMSetupBase
	{
		public StateSetupBase moving;
		public DodgeStateSetup dodge;
		public MeleeAttackStateBaseSetup melee0;
		public MeleeAttackStateBaseSetup melee1;
	}
}