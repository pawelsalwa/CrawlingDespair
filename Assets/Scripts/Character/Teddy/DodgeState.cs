using Character.FSMSetupData;
using Character.Teddy.TeddyFSM;
using UnityEngine;

namespace Character.Teddy
{
	public class DodgeState : TeddyStateBase
	{
		private DodgeStateSetup DodgeStateSetup => stateSetupBase as DodgeStateSetup;
		
		public DodgeState(CharacterTeddy teddy, TeddyFsm fsm, DodgeStateSetup stateSetupBase) : base( teddy, fsm, stateSetupBase)
		{
		}

		protected override void OnEnter()
		{
			var dir = input.Movement.normalized;
			if (input.Movement.magnitude <= 0.1f) dir = Vector2.down;
			Teddy.TeddyAnimator.Dodge(dir);
		}

		protected override void OnUpdate()
		{
			if (input.Attack && stateProgress >= DodgeStateSetup.EnableAttackTreshold)
			{
				RequestTransition(TeddyFsm.Melee0);
				return;
			}
		}
	}
}