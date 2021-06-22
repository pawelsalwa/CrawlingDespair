using System;
using Character.Setup;

namespace Character.States
{
	public class Move : State
	{
		public Move(Fsm fsm, StateSetup stateSetup) : base(fsm, stateSetup)
		{
		}

		protected override Action AnimCall => Character.Animator.ToMoving;

		protected override void OnUpdate()
		{
			if (PlayerInput.Attack)
			{
				RequestTransition(fsm.Attack0);
				return;
			}

			if (PlayerInput.Dodge)
			{
				RequestTransition(fsm.Dodge);
				return;
			}
		}

		protected override void OnFixedUpdate()
		{
			Character.Movement.MoveByInput(PlayerInput.Movement, PlayerInput.Run);
			Character.Movement.SetLookAtAngle(PlayerInput.LookAtAngle);
		}
	}
}