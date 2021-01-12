using Character.FSMSetupData;

namespace Character.Teddy
{
	public class TeddyStateBase : CharacterStateBase
	{
		
		protected CharacterTeddy Teddy => characterBase as CharacterTeddy;
		protected TeddyFsm TeddyFsm => fsm as TeddyFsm;
		
		public TeddyStateBase(CharacterTeddy teddy, Fsm fsm, StateSetupBase stateSetupBase) : base(teddy, fsm, stateSetupBase)
		{
		}
	}
}