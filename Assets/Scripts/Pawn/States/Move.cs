using System;

namespace Pawn.States
{
	public class Move : State
	{
		public Move(Fsm fsm, StateSetup stateSetup) : base(fsm, stateSetup)
		{
		}

		protected override Action AnimCall => pawn.Animator.ToMoving;

		protected override void OnUpdate()
		{
			if (input.Attack)
			{
				RequestTransition(fsm.Attack0);
				return;
			}

			if (input.Dodge)
			{
				RequestTransition(fsm.Dodge);
				return;
			}
		}

		protected override void OnFixedUpdate()
		{
			pawn.Movement.MoveByInput(input.Movement, input.Run);
			pawn.Movement.SetLookAtAngle(input.LookAtAngle);
		}
	}
}