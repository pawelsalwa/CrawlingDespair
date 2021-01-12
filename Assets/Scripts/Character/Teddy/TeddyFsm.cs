using Character.FSMSetupData;
using Character.Teddy.TeddyFSM;

namespace Character.Teddy
{
	public class TeddyFsm : Fsm
	{

		public override CharacterStateBase DefaultState => Moving;
		
		public CharacterStateBase Moving;
		public CharacterStateBase Dodge;
		public MeleeAttackStateBase Melee0;
		public MeleeAttackStateBase Melee1;

		public TeddyFsm(CharacterTeddy teddy, TeddyStateMachineSetup fsmSetup) : base(teddy, fsmSetup)
		{
			Moving = new MovingState(teddy, this, fsmSetup.moving);
			Dodge = new DodgeState(teddy, this, fsmSetup.dodge);
			Melee0 = new Melee0State(teddy, this, fsmSetup.melee0);
			Melee1 = new MeleeAttackStateBase(teddy, this, fsmSetup.melee1);
			PerformTransition(Moving);
		}
	}
}