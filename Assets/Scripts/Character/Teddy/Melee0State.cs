using System;
using Character.Teddy.TeddyFSM;

namespace Character.Teddy
{
	public class Melee0State : MeleeAttackStateBase
	{
		public Melee0State(CharacterTeddy teddy, TeddyFsm fsm, MeleeAttackStateBaseSetup stateSetupBase) : base(teddy, fsm, stateSetupBase)
		{
		}

		protected override TeddyStateBase NextMeleeAttackComboState => TeddyFsm.Melee1;

		protected override Action AnimCallback => Teddy.TeddyAnimator.Melee0;
	}
}