using System;
using Character.FSMSetupData;
using Character.Teddy.TeddyFSM;
using UnityEngine.Serialization;

namespace Character.Teddy
{
	[Serializable]
	public class TeddyStateMachineSetup : CharacterFSMSetupBase
	{
		[FormerlySerializedAs("movingStateSetup")] public StateSetupBase moving;
		public MeleeAttackStateBaseSetup melee0;
		public MeleeAttackStateBaseSetup melee1;
	}
}