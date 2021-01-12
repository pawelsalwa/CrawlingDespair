using System;
using Pawn.Setup;

namespace Pawn.States
{
	public class Attack1 : AttackBase
	{
		public Attack1( Fsm fsm, AttackSetup setup) : base( fsm, setup)
		{
		}

		protected override Action AnimCall => pawn.Animator.Melee1;

		protected override State NextComboState => fsm.Attack0;
	}
}