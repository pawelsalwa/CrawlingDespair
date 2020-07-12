using Character.FSMSetupData;
using UnityEngine;

namespace Character
{
	public class HitState : CharacterStateBase
	{
		// private HitStateData hitStateData => stateDataBase as HitStateData;
		//
		public HitState(CharacterInputBase characterInput, CharacterBase characterBase, CharacterStateMachineBase stateMachine, StateSetupBase hitStateSetupBase) : base(characterInput, characterBase, stateMachine, hitStateSetupBase)
		{
		}
		//
		// protected override CharacterStateBase DefaultNextState => 
		// 	DoesCurrentEffectPutCharacterOnTheGround() ?
		// 		stateMachine.GetUpStateBase : 
		// 		stateMachine.DefaultState;
		//
		// protected override float StateDuration => hitStateData.GetStateDurationFromEffect(CurrentDamageData.Effect);
		// private float KnockbackDistance => hitStateData.GetKnockbackDistanceFromEffect(CurrentDamageData.Effect);
		//
		// public DamageData CurrentDamageData { set; private get; }
		// protected bool SourceOfDmgIsToTheRight => CurrentDamageData.SourcePosition.x > characterBase.transform.position.x;
		//
		// private float areaUnderCurve = 0f;
		//
		// public void OnDamageTaken(DamageData newDamageData)
		// {
		// 	CurrentDamageData = AdjustDamageEffect(newDamageData);
		// 	RequestTransition(this);
		// }
		//
		// private DamageData AdjustDamageEffect(DamageData newDamageData)
		// {
		// 	if (stateMachine.IsHanging)
		// 	{
		// 		newDamageData.Effect = DamageData.DamageEffect.KnockDown;
		// 		return newDamageData;
		// 	}
		// 	
		// 	if (stateMachine.IsKneeling && newDamageData.Type == DamageData.DamageType.Firearm) // case of combat scenario: kneel by hook => shoot
		// 	{
		// 		newDamageData.Effect = DamageData.DamageEffect.KnockDown;
		// 		return newDamageData;
		// 	}
		//
		// 	if (!Active)
		// 	{
		// 		return newDamageData;
		// 	} 
		//
		// 	if (DoesCurrentEffectPutCharacterOnTheGround())
		// 	{
		// 		Debug.Log($"<color=white>taking damage while lying occured</color>");
		// 		newDamageData.Effect = DamageData.DamageEffect.DamagingLyingCharacter;
		// 	}
		// 	
		// 	return newDamageData;
		// }
		//
		// protected override void OnEnter()
		// {
		// 	if (!characterBase.CharacterHealth.IsHpAboveZero)
		// 	{
		// 		RequestTransition(stateMachine.DeadStateBase);
		// 		return;
		// 	}
		//
		// 	characterBase.CharacterAnimator.TakeDamage(CurrentDamageData.Effect);
		// 	areaUnderCurve = hitStateData.xMovingCurve.IntegrateCurve(0f, 1f, 20);
		//
		// 	if (CurrentDamageData.Effect == DamageData.DamageEffect.KnockUp)
		// 	{
		// 		Vector2 Motion = new Vector2((SourceOfDmgIsToTheRight ? -1 : 1) * hitStateData.KnockUpMotion.x, hitStateData.KnockUpMotion.y);
		// 		(characterBase.CharacterMovement as BipedMovement).SetCurrentMotion(Motion);
		// 	}
		// }
		//
		// protected override void OnUpdate() => ApplyHitMovement();
		//
		// private void ApplyHitMovement()
		// {
		// 	if (CurrentDamageData.Effect == DamageData.DamageEffect.KnockUp)
		// 	{
		// 		return; // knockup is movement in air that is added only once at the beginning
		// 	}
		// 	
		// 	var currentVel = hitStateData.xMovingCurve.Evaluate(stateProgress / StateDuration) * KnockbackDistance;
		// 	if (Mathf.Approximately(StateDuration, 0f) || Mathf.Approximately(areaUnderCurve, 0f)) 
		// 		Debug.LogError($"<color=red>DIVIDING BY ZERO DETECTED!!! City evacuation has commenced.</color>"); // most likely curve is not setup and its default integral is 0
		// 	else
		// 	{
		// 		currentVel /= StateDuration;
		// 		currentVel /= areaUnderCurve;
		// 	}
		// 	characterBase.CharacterMovement.ForceXMove(currentVel * (SourceOfDmgIsToTheRight ? -1f : 1f), false);
		// }
		//
		// private bool DoesCurrentEffectPutCharacterOnTheGround()
		// {
		// 	switch (CurrentDamageData.Effect)
		// 	{
		// 		case DamageData.DamageEffect.KnockUp:
		// 		case DamageData.DamageEffect.KnockDown:
		// 		case DamageData.DamageEffect.Kicked:
		// 		case DamageData.DamageEffect.Trapped:
		// 		case DamageData.DamageEffect.PushedByFailedHookPull:
		// 		case DamageData.DamageEffect.FalldownHigh:
		// 		case DamageData.DamageEffect.DamagingLyingCharacter:
		// 			return true;
		// 		default: 
		// 			return false;
		// 	}
		// }
	}
}
