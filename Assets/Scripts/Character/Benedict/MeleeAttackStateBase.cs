// using Character.Benedict.BenedictStates;
// using Character.FSMSetupData;
// using GameCore;
// using GameCore.ExtensionMethods;
// using UnityEngine;
//
// namespace Character.Benedict
// {
// 	/// <summary> Base class for melee attack states. Takes care of dealing damage, and transitions to next combo part or MovingState. </summary>
// 	public abstract class MeleeAttackStateBase : BenedictStateBase
// 	{
// 		protected MeleeAttackStateBaseData MeleeAttackStateBaseData => stateDataBase as MeleeAttackStateBaseData;
//
// 		/// <summary> Derived states should implement this if they have next combo part. If it's null, that means there's no combo. </summary>
// 		protected virtual BenedictStateBase NextMeleeAttackComboState => null;
//
// 		protected bool comboActivated = false;
// 		private bool inputReset = false;
// 		
// 		protected virtual DamageData.DamageEffect DamageEffect => MeleeAttackStateBaseData.DamageEffect;
//
// 		private bool ShouldTransitionToNextCombo =>
// 			stateProgress > MeleeAttackStateBaseData.TransitionToNextComboExitTime && comboActivated;
//
// 		private bool IsInComboWindow =>
// 			stateProgress > MeleeAttackStateBaseData.ComboWindowStart &&
// 			stateProgress < MeleeAttackStateBaseData.ComboWindowEnd;
//
// 		protected bool IsInDealingDmgWindow =>
// 			fixedStateProgress > MeleeAttackStateBaseData.DealDmgWindowStart &&
// 			fixedStateProgress < MeleeAttackStateBaseData.DealDmgWindowEnd;
//
// 		private float areaUnderCurve = 0f;
// 		
// 		protected MeleeAttackStateBase(BenedictInput characterInput, CharacterBenedict characterBase, BenedictStateMachine stateMachine, MeleeAttackStateBaseData meleeAttackStateBaseData) : base(
// 			characterInput, characterBase, stateMachine, meleeAttackStateBaseData)
// 		{
// 		}
//
// 		protected override void OnEnter()
// 		{
// 			comboActivated = inputReset = false;
// 			areaUnderCurve = MeleeAttackStateBaseData.MovingCurve.IntegrateCurve(0f, 1f, 20);
// 		}
//
// 		protected override void OnUpdate()
// 		{
// 			ApplyAttackMovement();
//
// 			inputReset = inputReset || !BenedictInput.Attack;
//
// 			if (BenedictInput.Attack && IsInComboWindow && inputReset)
// 				comboActivated = true;
//
// 			if (ShouldTransitionToNextCombo && NextMeleeAttackComboState != null)
// 			{
// 				RequestTransition(NextMeleeAttackComboState);
// 				return;
// 			}
// 		}
//
// 		protected override void OnFixedUpdate()
// 		{
// 			if (IsInDealingDmgWindow)
// 			{
// 				CharacterBenedict.CharacterMeleeCombat.StartDealingMeleeDmg(DamageEffect);
// 			}
// 			else
// 			{
// 				CharacterBenedict.CharacterMeleeCombat.EndDealingMeleeDmg();
// 			}
// 		}
//
// 		protected override void OnExit() => CharacterBenedict.CharacterMeleeCombat.EndDealingMeleeDmg();
// 		
// 		private void ApplyAttackMovement()
// 		{
// 			var currentVel = MeleeAttackStateBaseData.MovingCurve.Evaluate(ProgressPercentage) * MeleeAttackStateBaseData.MovingDistance;
// 			if (Mathf.Approximately(MeleeAttackStateBaseData.StateDuration, 0f) || Mathf.Approximately(areaUnderCurve, 0f)) 
// 				Debug.LogError($"<color=red>DIVIDING BY ZERO DETECTED!!! City evacuation has commenced.</color>");
// 			else
// 			{
// 				currentVel /= MeleeAttackStateBaseData.StateDuration;
// 				currentVel /= areaUnderCurve;
// 			}
// 			characterBase.CharacterMovement.ForceXMove(currentVel * (characterBase.FacingRight ? 1f : -1f), MeleeAttackStateBaseData.ApplyInAir);
// 			characterBase.CharacterMovement.StopWalking();
// 		}
// 		//
// 		// private void ApplyAttackMovement() // TODO integral curves
// 		// {
// 		// 	float x = MeleeAttackStateBaseData.MovingCurve.Evaluate(ProgressPercentage) *
// 		// 	          (CharacterBenedict.FacingRight ? 1f : -1f);
// 		// 	// Vector2 motion = new Vector2(x, 0f);
// 		// 	CharacterBenedict.BipedMovement.ForceXMove(x, MeleeAttackStateBaseData.ApplyInAir);
// 		// }
// 	}
// }