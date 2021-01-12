using System;
using Pawn.Setup;

namespace Pawn.States
{
	public class Attack0 : AttackBase
	{
		public Attack0( Fsm fsm, AttackSetup setup) : base( fsm, setup)
		{
		}

		protected override State NextComboState => fsm.Attack1;

		protected override Action AnimCall => pawn.Animator.Melee0;
	}
}