// using Character.Benedict.BenedictStates;
// using Character.Benedict.Setup;
// using GameCore;
//
// namespace Character.Benedict
// {
// 	public class BenedictStateMachine : CharacterStateMachineBase
// 	{
// 		public readonly IdleState IdleState;
// 		public readonly MovingState MovingState;
// 		public readonly DodgingState DodgingState;
// 		public readonly TackleState TackleState;
// 		
// 		public readonly AimingState AimingState;
// 		public readonly JumpOverSomethingState JumpOverSomethingState;
// 		public readonly PreAttackState PreAttackState;
//
// 		public readonly MeleeAttackUpwardsState MeleeAttackUpwardsState;
// 		public readonly MeleeAttackDownwardsState MeleeAttackDownwardsState;
// 		public readonly MeleeAttackThrustState MeleeAttackThrustState;
// 		public readonly MeleeAttackJumpSlashDownwardsState MeleeAttackJumpSlashDownwardsState;
// 		
// 		public readonly MeleeAttackChanneledState MeleeAttackChanneledState;
// 		public readonly MeleeAttackUpwardsFromSprintState MeleeAttackUpwardsFromSprintState;
// 		public readonly MeleeAttackUpwardsFromAimingHookState MeleeAttackUpwardsFromAimingHookState;
// 		public readonly MeleeAttackThrustFromDodgeState MeleeAttackThrustFromDodgeState;
//
// 		// public readonly SetHookTrapState SetHookTrapState;
// 		public readonly HookThrowingState HookThrowingState;
// 		public readonly HookJumpState HookJumpState;
// 		// public readonly HookPullingEnemyState HookPullingEnemyState;
// 		public readonly AimingHookThrowingState AimingHookThrowingState;
// 		public readonly AimingHookPullingEnemyState AimingHookPullingEnemyState;
// 		public readonly StepOnHookLineState StepOnHookLineState;
// 		public readonly SetAnchorState SetAnchorState;
// 		public readonly AfterAnchorTeleportationState AfterAnchorTeleportationState;
//
// 		public readonly BlockingState BlockingState;
// 		public readonly ReloadingState ReloadingState;
// 		public readonly EquipmentUseState EquipmentUseState;
// 		public readonly InteractingState InteractingState;
//
// 		public readonly CatchingLedgeState CatchingLedgeState;
// 		public readonly HangingState HangingState;
// 		public readonly ClimbingState ClimbingState;
// 		public readonly LowClimbState LowClimbState;
// 		public readonly GetUpState GetUpState;
// 		
// 		public readonly HitState HitState;
// 		public readonly AnyState AnyState;
// 		public readonly DeadState DeadState;
//
// 		public override CharacterStateBase DefaultState => MovingState;
// 		public override CharacterStateBase GetUpStateBase => GetUpState;
// 		public override CharacterStateBase DeadStateBase => DeadState;
// 		
//
// 		public BenedictStateMachine(BenedictInput benedictInput, CharacterBenedict characterBenedict, BenedictFsmSetup benedictFsmSetup) : base(benedictInput, characterBenedict, benedictFsmSetup)
// 		{
// 			IdleState = new IdleState(benedictInput, characterBenedict, this, benedictFsmSetup.IdleStateData);
// 			MovingState = new MovingState(benedictInput, characterBenedict, this, benedictFsmSetup.MovingStateData);
// 			DodgingState = new DodgingState(benedictInput, characterBenedict, this, benedictFsmSetup.DodgingStateData);
// 			TackleState = new TackleState(benedictInput, characterBenedict, this, benedictFsmSetup.TackleStateData);
// 			
// 			AimingState = new AimingState(benedictInput, characterBenedict, this, benedictFsmSetup.AimingStateData);
// 			JumpOverSomethingState = new JumpOverSomethingState(benedictInput, characterBenedict, this, benedictFsmSetup.JumpOverSomethingStateData);
// 			PreAttackState = new PreAttackState(benedictInput, characterBenedict, this, benedictFsmSetup.PreAttackStateData);
//
// 			MeleeAttackUpwardsState = new MeleeAttackUpwardsState(benedictInput, characterBenedict, this, benedictFsmSetup.MeleeAttackUpwardsStateData);
// 			MeleeAttackDownwardsState = new MeleeAttackDownwardsState(benedictInput, characterBenedict, this, benedictFsmSetup.MeleeAttackDownwardsStateData);
// 			MeleeAttackThrustState = new MeleeAttackThrustState(benedictInput, characterBenedict, this, benedictFsmSetup.MeleeAttackThrustStateData);
// 			MeleeAttackThrustFromDodgeState = new MeleeAttackThrustFromDodgeState(benedictInput, characterBenedict, this, benedictFsmSetup.MeleeAttackThrustFromDodgeStateData);
// 			
// 			MeleeAttackJumpSlashDownwardsState = new MeleeAttackJumpSlashDownwardsState(benedictInput, characterBenedict, this, benedictFsmSetup.MeleeAttackJumpSlashDownwardsStateData);
// 			MeleeAttackUpwardsFromSprintState = new MeleeAttackUpwardsFromSprintState(benedictInput, characterBenedict, this, benedictFsmSetup.MeleeAttackUpwardsFromSprintStateData);
// 			MeleeAttackUpwardsFromAimingHookState = new MeleeAttackUpwardsFromAimingHookState(benedictInput, characterBenedict, this, benedictFsmSetup.MeleeAttackUpwardsFromAimingHookStateData);
// 			MeleeAttackChanneledState = new MeleeAttackChanneledState(benedictInput, characterBenedict, this, benedictFsmSetup.MeleeAttackChanneledStateData);
//
// 			// SetHookTrapState = new SetHookTrapState(benedictInput, characterBenedict, this/*, benedictFsmSetup.HookThrowingStateData*/);
// 			HookThrowingState = new HookThrowingState(benedictInput, characterBenedict, this, benedictFsmSetup.HookThrowingStateData);
// 			HookJumpState = new HookJumpState(benedictInput, characterBenedict, this, benedictFsmSetup.hookJumpStateData);
// 			// HookPullingEnemyState = new HookPullingEnemyState(benedictInput, characterBenedict, this, benedictFsmSetup.HookPullingEnemyStateData);
// 			AimingHookThrowingState = new AimingHookThrowingState(benedictInput, characterBenedict, this, benedictFsmSetup.aimingHookThrowingStateData);
// 			AimingHookPullingEnemyState = new AimingHookPullingEnemyState(benedictInput, characterBenedict, this, benedictFsmSetup.aimingHookPullingEnemyStateData);
// 			StepOnHookLineState = new StepOnHookLineState(benedictInput, characterBenedict, this, benedictFsmSetup.StepOnHookLineStateData);
// 			SetAnchorState = new SetAnchorState(benedictInput, characterBenedict, this, benedictFsmSetup.SetAnchorStateData);
// 			AfterAnchorTeleportationState = new AfterAnchorTeleportationState(benedictInput, characterBenedict, this,
// 				benedictFsmSetup.AfterAnchorTeleportationStateData);
//
// 			BlockingState = new BlockingState(benedictInput, characterBenedict, this, benedictFsmSetup.BlockingStateData);
// 			ReloadingState = new ReloadingState(benedictInput, characterBenedict, this, benedictFsmSetup.ReloadingStateData);
// 			EquipmentUseState = new EquipmentUseState(benedictInput, characterBenedict, this, benedictFsmSetup.EquipmentUseStateData);
// 			InteractingState = new InteractingState(benedictInput, characterBenedict, this, benedictFsmSetup.InteractingStateData);
//
// 			CatchingLedgeState = new CatchingLedgeState(benedictInput, characterBenedict, this, benedictFsmSetup.CatchingLedgeStateData);
// 			HangingState = new HangingState(benedictInput, characterBenedict, this, benedictFsmSetup.HangingStateData);
// 			ClimbingState = new ClimbingState(benedictInput, characterBenedict, this, benedictFsmSetup.ClimbingStateData);
// 			LowClimbState = new LowClimbState(benedictInput, characterBenedict, this, benedictFsmSetup.LowClimbStateData);
// 			GetUpState = new GetUpState(benedictInput, characterBenedict, this, benedictFsmSetup.GetUpStateData);
// 			
// 			HitState = new HitState(benedictInput, characterBenedict, this, benedictFsmSetup.hitStateData);
// 			AnyState = new AnyState(benedictInput, characterBenedict, this, benedictFsmSetup.AnyStateData);
// 			DeadState = new DeadState(benedictInput, characterBenedict, this, benedictFsmSetup.DeadStateData);
//
// 			// SetAnyState(AnyState);
// 			PerformTransition(IdleState);
// 		}
//
// 		///<Summary>
// 		/// HitState transitions:
// 		/// <see href="https://www.notion.so/244c6b1f54a54aaf99ec1063e917e3bc?v=411c98bd616641ba8c594c157b727521"> asdads asdasdasd </see>
// 		///</Summary>
// 		public override void Update()
// 		{
// 			AnyState.Update();
// 			base.Update();
// 		}
//
// 		public void OnDamageTaken(DamageData damageData) => HitState.OnDamageTaken(damageData);
// 	}
// }