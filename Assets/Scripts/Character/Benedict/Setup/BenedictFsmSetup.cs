// using System;
// using Character.Benedict.BenedictStates;
// using Character.FSMSetupData;
// using UnityEngine;
//
// namespace Character.Benedict.Setup
// {
// 	[Serializable]
// 	public class BenedictFsmSetup : CharacterFSMSetupBase
// 	{
// 		public StateDataBase IdleStateData;
// 		public MovingStateData MovingStateData;
// 		public DodgingStateData DodgingStateData;
// 		public TackleStateData TackleStateData;
// 		
// 		public AimingStateData AimingStateData;
// 		public StateDataBase JumpOverSomethingStateData;
// 		public PreAttackStateData PreAttackStateData;
//
// 		public StateDataBase HookThrowingStateData;
// 		public StateDataBase hookJumpStateData;
// 		public StateDataBase HookPullingEnemyStateData;
// 		public AimingHookThrowingStateData aimingHookThrowingStateData;
// 		public StateDataBase StepOnHookLineStateData;
// 		public StateDataBase aimingHookPullingEnemyStateData;
// 		public SetAnchorStateData SetAnchorStateData;
// 		public AfterAnchorTeleportationStateData AfterAnchorTeleportationStateData;
// 		public BlockingStateData BlockingStateData;
// 		public StateDataBase ReloadingStateData;
// 		public StateDataBase EquipmentUseStateData;
// 		public InteractingStateData InteractingStateData;
// 		
// 		public CatchingLedgeStateData CatchingLedgeStateData;
// 		public HangingStateData HangingStateData;
// 		public ClimbingStateData ClimbingStateData;
// 		public ClimbingStateData LowClimbStateData;
// 		public StateDataBase GetUpStateData;
//
// 		public HitStateData hitStateData;
// 		public AnyStateData AnyStateData;
// 		public DeadStateData DeadStateData;
// 		
// 		[Header("Melee States")]
// 		public MeleeAttackStateBaseData MeleeAttackUpwardsStateData;
// 		public MeleeAttackStateBaseData MeleeAttackDownwardsStateData;
// 		public MeleeAttackStateBaseData MeleeAttackThrustStateData;
// 		public MeleeAttackStateBaseData MeleeAttackJumpSlashDownwardsStateData;
// 		
// 		public MeleeAttackStateBaseData MeleeAttackChanneledStateData;
// 		public MeleeAttackStateBaseData MeleeAttackUpwardsFromSprintStateData;
// 		public MeleeAttackStateBaseData MeleeAttackThrustFromDodgeStateData;
// 		public MeleeAttackStateBaseData MeleeAttackUpwardsFromAimingHookStateData;
// 	}
// }