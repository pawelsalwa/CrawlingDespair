using System;

namespace Character.Teddy.TeddyFSM
{
	public class MeleeAttackStateBase : TeddyStateBase
	{
		public MeleeAttackStateBase(CharacterTeddy teddy, TeddyFsm fsm, MeleeAttackStateBaseSetup stateSetupBase) : base(teddy, fsm, stateSetupBase)
		{
			
		}
		
		protected MeleeAttackStateBaseSetup MeleeAttackStateBaseData => stateSetupBase as MeleeAttackStateBaseSetup;

		/// <summary> Derived states should implement this if they have next combo part. If it's null, that means there's no combo. </summary>
		protected virtual TeddyStateBase NextMeleeAttackComboState => null;

		protected bool comboActivated = false;
		private bool inputReset = false;

		private bool ShouldTransitionToNextCombo =>
			stateProgress > MeleeAttackStateBaseData.TransitionToNextComboExitTime && comboActivated;

		private bool IsInComboWindow =>
			stateProgress > MeleeAttackStateBaseData.ComboWindowStart &&
			stateProgress < MeleeAttackStateBaseData.ComboWindowEnd;

		protected bool IsInDealingDmgWindow =>
			fixedStateProgress > MeleeAttackStateBaseData.DealDmgWindowStart &&
			fixedStateProgress < MeleeAttackStateBaseData.DealDmgWindowEnd;

		// private float areaUnderCurve = 0f;

		protected virtual Action AnimCallback => Teddy.TeddyAnimator.Melee1;

		protected override void OnEnter()
		{
			AnimCallback();
			comboActivated = inputReset = false;
			// areaUnderCurve = MeleeAttackStateBaseData.MovingCurve.IntegrateCurve(0f, 1f, 20);
		}

		protected override void OnUpdate()
		{
			// Teddy.CharacterMovementBase.MoveByInput(TeddyInput.Movement, TeddyInput.Run);
			//ApplyAttackMovement();

			inputReset = inputReset || !input.Attack;

			if (input.Attack && IsInComboWindow && inputReset)
				comboActivated = true;

			if (ShouldTransitionToNextCombo && NextMeleeAttackComboState != null)
			{
				RequestTransition(NextMeleeAttackComboState);
				return;
			}

			UpdateTrail();
		}

		private void UpdateTrail()
		{
			Teddy.Refs.Trail.SetActive(stateProgress >= MeleeAttackStateBaseData.TrailStart && stateProgress <= MeleeAttackStateBaseData.TrailEnd);
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
		
		// private void ApplyAttackMovement()
		// {
		// 	var currentVel = MeleeAttackStateBaseData.MovingCurve.Evaluate(ProgressPercentage) * MeleeAttackStateBaseData.MovingDistance;
		// 	if (Mathf.Approximately(MeleeAttackStateBaseData.StateDuration, 0f) || Mathf.Approximately(areaUnderCurve, 0f)) 
		// 		Debug.LogError($"<color=red>DIVIDING BY ZERO DETECTED!!! City evacuation has commenced.</color>");
		// 	else
		// 	{
		// 		currentVel /= MeleeAttackStateBaseData.StateDuration;
		// 		currentVel /= areaUnderCurve;
		// 	}
		// 	
		// 	
		//
		// 	Teddy.CharacterMovementBase.ForceMoveForward(currentVel * Time.deltaTime);
		// 	
		// 	// characterBase.CharacterMovement.ForceXMove(currentVel * (characterBase.FacingRight ? 1f : -1f), MeleeAttackStateBaseData.ApplyInAir);
		// 	// characterBase.CharacterMovement.StopWalking();
		// }
	}
}