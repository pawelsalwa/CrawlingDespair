using System;
using Character.States;

namespace Pawn.States
{
	public class Melee0 : AttackState
	{
		public Melee0( Fsm fsm, MeleeStateSetup setup) : base( fsm, setup)
		{
		}

		protected override Action AnimCall => pawn.Animator.Melee0;
	}
}