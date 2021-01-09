using System;
using Character.Teddy.TeddyFSM;

namespace Character.Teddy
{
	public class Melee0State : MeleeAttackStateBase
	{
		public Melee0State(TeddyInput input, CharacterTeddy teddy, TeddyStateMachine teddyStateMachine, MeleeAttackStateBaseSetup stateSetupBase) : base(input, teddy, teddyStateMachine, stateSetupBase)
		{
		}

		protected override TeddyStateBase NextMeleeAttackComboState => TeddyStateMachine.Melee1;

		protected override Action AnimCallback => Teddy.TeddyAnimator.Melee0;
	}
}