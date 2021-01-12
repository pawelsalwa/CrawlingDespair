using System;
using UnityEngine;

namespace Character.States
{
	public class DodgeState : State
	{
		private DodgeStateSetup DodgeStateSetup => stateSetup as DodgeStateSetup;
		
		public DodgeState(Fsm fsm, DodgeStateSetup stateSetup) : base( fsm, stateSetup)
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
			if (input.Attack && stateProgress >= DodgeStateSetup.EnableAttackTreshold)
			{
				RequestTransition(fsm.Attack0);
				return;
			}
		}
	}
}