using Character.FSMSetupData;
using Character.Teddy.TeddyFSM;

namespace Character.Teddy
{
	public class TeddyStateMachine : CharacterStateMachineBase
	{

		public override CharacterStateBase DefaultState => MovingState;
		
		public CharacterStateBase MovingState;
		public MeleeAttackStateBase MeleeAttackStateBase;

		public TeddyStateMachine(TeddyInput input, CharacterTeddy teddy, TeddyStateMachineSetup teddyStateMachineSetup) : base(input, teddy, teddyStateMachineSetup)
		{
			MovingState = new MovingState(input,teddy, this, teddyStateMachineSetup.movingStateSetup);
			MeleeAttackStateBase = new MeleeAttackStateBase(input,teddy, this, teddyStateMachineSetup.attackStateSetup);
			PerformTransition(MovingState);
		}

	}
}