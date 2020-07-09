using Character.FSMSetupData;

namespace Character.Teddy
{
	public class TeddyStateBase : CharacterStateBase
	{
		protected TeddyInput TeddyInput => characterInput as TeddyInput;
		protected CharacterTeddy Teddy => characterBase as CharacterTeddy;
		protected TeddyStateMachine TeddyStateMachine => stateMachine as TeddyStateMachine;
		
		public TeddyStateBase(TeddyInput input, CharacterTeddy teddy, TeddyStateMachine teddyStateMachine, StateDataBase stateDataBase) : base(input, teddy, teddyStateMachine, stateDataBase)
		{
		}
	}
}