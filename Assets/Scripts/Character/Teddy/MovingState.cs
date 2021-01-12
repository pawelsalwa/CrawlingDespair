using Character.FSMSetupData;

namespace Character.Teddy
{
	public class MovingState : TeddyStateBase
	{
		public MovingState(CharacterTeddy teddy, TeddyFsm fsm, StateSetupBase stateSetupBase) : base(teddy, fsm, stateSetupBase)
		{
		}

		protected override void OnEnter() => Teddy.TeddyAnimator.ReturnToDefault();

		protected override void OnUpdate()
		{
			Teddy.Movement.MoveByInput(input.Movement, input.Run);

			if (input.Attack)
			{
				RequestTransition(TeddyFsm.Melee0);
				return;
			}

			if (input.Dodge)
			{
				RequestTransition(TeddyFsm.Dodge);
				return;
			}
		}
	}
}