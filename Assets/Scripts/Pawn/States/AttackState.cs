using System;
using Character.States;

namespace Pawn.States
{
	public class AttackState : State
	{
		public AttackState( Fsm fsm, MeleeStateSetup setup) : base( fsm, setup)
		{ }
		
		protected MeleeStateSetup MeleeStateData => stateSetup as MeleeStateSetup;

		/// <summary> Derived states should implement this if they have next combo part. If it's null, that means there's no combo. </summary>
		protected virtual State NextComboState => null;

		protected bool comboActivated = false;
		private bool inputReset = false;

		private bool ShouldTransitionToNextCombo =>
			stateProgress > MeleeStateData.TransitionToNextComboExitTime && comboActivated;

		private bool IsInComboWindow =>
			stateProgress > MeleeStateData.ComboWindowStart &&
			stateProgress < MeleeStateData.ComboWindowEnd;

		protected bool IsInDealingDmgWindow =>
			fixedStateProgress > MeleeStateData.DealDmgWindowStart &&
			fixedStateProgress < MeleeStateData.DealDmgWindowEnd;

		protected override Action AnimCall => pawn.Animator.Melee0;

		protected override void OnEnter()
		{
			comboActivated = inputReset = false;
		}

		protected override void OnUpdate()
		{
			inputReset = inputReset || !input.Attack;

			if (input.Attack && IsInComboWindow && inputReset)
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