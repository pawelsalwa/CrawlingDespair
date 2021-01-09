using Character.FSMSetupData;
using Character.Teddy.TeddyFSM;

namespace Character.Teddy
{
	public class TeddyStateMachine : CharacterStateMachineBase
	{

		public override CharacterStateBase DefaultState => Moving;
		
		public CharacterStateBase Moving;
		public MeleeAttackStateBase Melee0;
		public MeleeAttackStateBase Melee1;

		public TeddyStateMachine(TeddyInput input, CharacterTeddy teddy, TeddyStateMachineSetup fsmSetup) : base(input, teddy, fsmSetup)
		{
			Moving = new MovingState(input,teddy, this, fsmSetup.moving);
			Melee0 = new Melee0State(input,teddy, this, fsmSetup.melee0);
			Melee1 = new MeleeAttackStateBase(input,teddy, this, fsmSetup.melee1);
			PerformTransition(Moving);
		}
	}
}