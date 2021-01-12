using System;
using UnityEngine;

namespace Pawn.States
{
	public class Dodge : State
	{
		private DodgeSetup DodgeSetup => setup as DodgeSetup;
		
		public Dodge(Fsm fsm, DodgeSetup setup) : base( fsm, setup)
		{
		}

		protected override Action AnimCall => CallDodgeAnim;

		private void CallDodgeAnim()
		{
			var dir = input.Movement.normalized;
			if (input.Movement.magnitude <= 0.1f) dir = Vector2.down;
			pawn.Animator.Dodge(dir);
		}

		protected override void OnUpdate()
		{
			if (input.Attack && stateProgress >= DodgeSetup.EnableAttackTreshold)
			{
				RequestTransition(fsm.Attack0);
				return;
			}
		}
	}
}