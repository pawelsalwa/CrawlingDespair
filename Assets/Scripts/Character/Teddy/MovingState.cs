using Character.FSMSetupData;

namespace Character.Teddy
{
	public class MovingState : TeddyStateBase
	{
		public MovingState(TeddyInput input, CharacterTeddy teddy, TeddyStateMachine teddyStateMachine, StateSetupBase stateSetupBase) : base(input, teddy, teddyStateMachine, stateSetupBase)
		{
		}

		protected override void OnEnter() => Teddy.TeddyAnimator.ReturnToDefault();

		protected override void OnUpdate()
		{
			Teddy.Movement.MoveByInput(TeddyInput.Movement, TeddyInput.Run);

			if (TeddyInput.Attack)
			{
				RequestTransition(TeddyStateMachine.Melee0);
				return;
			}
		}
	}
}