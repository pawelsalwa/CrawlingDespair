using Character.FSMSetupData;

namespace Character.Teddy
{
	public class TeddyStateMachine : CharacterStateMachineBase
	{

		public CharacterStateBase MovingState;
		public override CharacterStateBase DefaultState => MovingState;
		
		
		public TeddyStateMachine(TeddyInput input, CharacterTeddy teddy, TeddyStateMachineSetup teddyStateMachineSetup) : base(input, teddy, teddyStateMachineSetup)
		{
			MovingState = new MovingState(input,teddy, this, teddyStateMachineSetup.MovingStateData);
			PerformTransition(MovingState);
		}

	}
}