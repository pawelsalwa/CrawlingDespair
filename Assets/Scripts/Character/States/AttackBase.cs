using System;
using Character.Setup;

namespace Character.States
{
	public class AttackBase : State
	{
		public AttackBase( Fsm fsm, AttackSetup setup) : base( fsm, setup)
		{ }
		
		protected AttackSetup setup => base.setup as AttackSetup;

		/// <summary> Derived states should implement this if they have next combo part. If it's null, that means there's no combo. </summary>
		protected virtual State NextComboState => null;

		protected bool comboActivated = false;
		private bool inputReset = false;

		private bool ShouldTransitionToNextCombo =>
			stateProgress > setup.TransitionToNextComboExitTime && comboActivated;

		private bool IsInComboWindow =>
			stateProgress > setup.ComboWindowStart &&
			stateProgress < setup.ComboWindowEnd;

		protected bool IsInDealingDmgWindow =>
			fixedStateProgress > setup.DealDmgWindowStart &&
			fixedStateProgress < setup.DealDmgWindowEnd;

		protected override Action AnimCall => Character.Animator.Melee0;

		protected override void OnEnter()
		{
			comboActivated = inputReset = false;
			Character.Movement.SetLookAtAngle(PlayerInput.LookAtAngle); // this makes cool rotation snap on attacking which feels kinda cool
		}

		protected override void OnUpdate()
		{
			inputReset = inputReset || !PlayerInput.Attack;

			if (PlayerInput.Attack && IsInComboWindow && inputReset)
				comboActivated = true;

			if (ShouldTransitionToNextCombo && NextComboState != null)
			{
				RequestTransition(NextComboState);
				return;
			}

			UpdateTrail();
		}

		private void UpdateTrail()
		{
			// Teddy.Refs.Trail.SetActive(stateProgress >= MeleeStateData.TrailStart && stateProgress <= MeleeStateData.TrailEnd);
		}

		protected override void OnFixedUpdate()
		{
			
			// if (IsInDealingDmgWindow)
			// {
			// 	CharacterTeddy.CharacterMeleeCombat.StartDealingMeleeDmg(DamageEffect);
			// }
			// else
			// {
			// 	CharacterTeddy.CharacterMeleeCombat.EndDealingMeleeDmg();
			// }
		}

		// protected override void OnExit() => CharacterTeddy.CharacterMeleeCombat.EndDealingMeleeDmg();
	}
}