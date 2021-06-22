using System;
using UnityEngine;

namespace Character.States
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
			var dir = PlayerInput.Movement.normalized;
			if (PlayerInput.Movement.magnitude <= 0.1f) dir = Vector2.down;
			Character.Animator.Dodge(dir);
		}

		protected override void OnUpdate()
		{
			if (PlayerInput.Attack && stateProgress >= DodgeSetup.EnableAttackTreshold)
			{
				RequestTransition(fsm.Attack0);
				return;
			}
		}
	}
}