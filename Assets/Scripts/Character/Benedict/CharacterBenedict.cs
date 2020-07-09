// using System;
// using System.Collections;
// using System.Threading.Tasks;
// using CameraRelated;
// using Character.FSMSetupData;
// using Character.SetupData;
// using Combat;
// using GameCore;
// using RootMotion.FinalIK;
// using Scriptables.Character.Runtime.Benedict;
// using Scriptables.Character.Setup.Benedict;
// using Scriptables.Events;
// using UnityEditor;
// using UnityEngine;
//
// namespace Character.Benedict
// {
// 	public class CharacterBenedict : CharacterBase
// 	{
//
// 		#region Components
//
// 		public CharacterMeleeCombat CharacterMeleeCombat { get; private set; }
// 		public CharacterAiming CharacterAiming { get; private set; }
// 		public CharacterShooting CharacterShooting { get; private set; }
// 		public CharacterConsumableEquipment CharacterConsumableEquipment { get; private set; }
// 		public BenedictInteraction BenedictInteraction { get; private set; }
// 		public BenedictHooking BenedictHooking { get; private set; }
// 		public BenedictAnchoring BenedictAnchoring { get; private set; }
// 		public BenedictBlocking BenedictBlocking { get; private set; }
// 		public BenedictClimbing BenedictClimbing { get; private set; }
// 		public BenedictHitFXHandler BenedictHitFXHandler => CharacterHitFXHandler as BenedictHitFXHandler;
//
// 		public AimIK AimIk => BenedictPrefabSetup.AimIk;
// 		public FullBodyBipedIK FullBodyBipedIk => BenedictPrefabSetup.FullBodyBipedIk;
// 		public GrounderFBBIK GrounderFBBIK => BenedictPrefabSetup.GrounderFBBIK;
// 		public Transform LookAtPoint => BenedictPrefabSetup.LookAtPoint;
// 		public BipedMovement BipedMovement => CharacterMovement as BipedMovement;
// 		public BenedictAnimator BenedictAnimator => CharacterAnimator as BenedictAnimator;
// 		public BenedictPrefabSetup BenedictPrefabSetup => prefabSetup as BenedictPrefabSetup;
// 		public BenedictStateMachine BenedictStateMachine => characterStateMachineBase as BenedictStateMachine;
//
// 		public BenedictRuntimeData BenedictRuntimeData => CharacterRuntimeDataBase as BenedictRuntimeData;
// 		private BenedictSetupData BenedictSetupData => CharacterSetupDataBase as BenedictSetupData;
//
// 		public BenedictExistenceIndicator BenedictExistenceIndicator;
//
// 		#endregion
//
// 		#region MonoBehaviours
//
// 		protected override void Start() // Order here matters due to events subscribing
// 		{
// 			base.Start();
//
// 			var benedictPrefabSetupHelper = new BenedictPrefabSetupHelper(this);
//
// 			CharacterAnimator = new BenedictAnimator(BenedictPrefabSetup.Animator, BenedictSetupData.BenedictAnimatorSetup);
// 			CharacterMovement = new BipedMovement(BenedictPrefabSetup, CharacterController, BenedictSetupData.BipedMovementSetup);
// 			CharacterMovement.OnGroundedStart += CharacterHealth.CheckFalldownDamage;
//
// 			CharacterMeleeCombat = new CharacterMeleeCombat(BenedictPrefabSetup.Dagger,
// 				BenedictPrefabSetup.MeleeDamageArea, CharacterController, BenedictPrefabSetup.CameraShakeEvent);
// 			CharacterAiming = new CharacterAiming(BenedictSetupData.CharacterAimingSetup, transform, LookAtPoint);
// 			CharacterShooting = new CharacterShooting(BenedictPrefabSetup.FlareGun);
// 			CharacterConsumableEquipment = new CharacterConsumableEquipment(this, BenedictPrefabSetup.consumableEquipment);
//
// 			characterInputBase = new BenedictInput();
// 			characterInputControllerBase = new BenedictInputController(BenedictSetupData.InputMappingWrapper,
// 				characterInputBase as BenedictInput);
// 			characterStateMachineBase = new BenedictStateMachine(characterInputBase as BenedictInput, this,
// 				BenedictSetupData.BenedictFsmSetup);
// 			// (characterStateMachineBase as BenedictStateMachine).debugsEnabled = true;
//
// 			CharacterHitFXHandler = new BenedictHitFXHandler(this);
// 			BenedictInteraction = new BenedictInteraction(this, BenedictPrefabSetup.BenedictInteractionDetector);
// 			BenedictBlocking = new BenedictBlocking();
// 			BenedictClimbing = new BenedictClimbing(BenedictPrefabSetup.FullBodyBipedIk, this, BenedictPrefabSetup.climbableLedgeDetector);
// 			BenedictHooking = new BenedictHooking(BenedictPrefabSetup.HookTrap, BenedictPrefabSetup.HookLineRenderer, prefabSetup.transform, prefabSetup.Belly, prefabSetup.ComponentsRoot, BenedictSetupData.BenedictHookingSetup);
// 			BenedictAnchoring = new BenedictAnchoring(this, BenedictSetupData.BenedictMaxAnchors);
// 			BenedictPrefabSetup.CharacterIKManager.InitBenedict(this);
// 			CharacterRagdoll = new CharacterRagdoll(this);
// 			CharacterRagdoll.SetupRagdollBones();
//
// 			CharacterHealth.OnDeath += () =>
// 			{
// 				Invoke(nameof(MarkDead), BenedictSetupData.BenedictFsmSetup.DeadStateData.bodyDestroyTimeout - 1);
// 				//Task.Delay(new TimeSpan(0, 0, (int)BenedictSetupData.BenedictFsmSetup.DeadStateData.bodyDestroyTimeout + 2)).ContinueWith(o => { BenedictExistenceIndicator.MarkDead(); });
// 			};
//
// 			// probably best place to call it
// 			BenedictPrefabSetup.CameraSwitchEvent.RaiseEvent(new CameraSwitchData
// 			{
// 				VirtualCameraFollowTransform = transform,
// 				UsePredefinedCamera = true,
// 				TargetPredefinedCameraType = PredefinedCameraType.BenedictHudDefaultCamera
// 			});
// 		}
//
// 		protected override void Update()
// 		{
// 			base.Update();
// 			CharacterAiming.Update();
// 			BenedictPrefabSetup.AimIk.solver.IKPositionWeight = CharacterAiming.Progress;
//
// 			CharacterAnimator.Update(
// 				new UpdateAnimDataBase
// 				{
// 					velocity = BipedMovement.Velocity,
// 					isGrounded = BipedMovement.Grounded,
// 					isCrouching = BipedMovement.IsCrouching,
// 					aimingProgress = CharacterAiming.Progress,
// 				});
// 		}
//
// 		#endregion
//
// 		#region Utilities
//
// 		protected override void OnDamageTaken(DamageData damageData)
// 		{
// 			BenedictStateMachine.OnDamageTaken(damageData);
// 			BenedictPrefabSetup.CameraShakeEvent.RaiseEvent(CameraShakeEvent.CameraShakeType.BenedictTakingDmg); // testowo
// 		}
//
// 		public DamageData debugDamageData;
// 		[ContextMenu("TakeDebugDamage()")]
// 		private void TakeDebugDamage() => TakeDamage(debugDamageData);
//
// 		public override void SwitchOnComponents() => FullBodyBipedIk.enabled = GrounderFBBIK.enabled = true;
//
// 		public override void SwitchOffComponents() => FullBodyBipedIk.enabled = GrounderFBBIK.enabled = false;
//
// 		private void MarkDead()
// 		{
// 			BenedictExistenceIndicator.MarkDead();
// 		}
//
// #endregion
//
// 	}
// }