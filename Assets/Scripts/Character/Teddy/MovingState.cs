using Character.FSMSetupData;

namespace Character.Teddy
{
	public class MovingState : TeddyStateBase
	{
		public MovingState(TeddyInput input, CharacterTeddy teddy, TeddyStateMachine teddyStateMachine, StateDataBase stateDataBase) : base(input, teddy, teddyStateMachine, stateDataBase)
		{
		}

		protected override void OnUpdate()
		{
			Teddy.CharacterMovementBase.MoveByInput(TeddyInput.Movement);
		}
	}
}