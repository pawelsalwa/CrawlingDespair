// using System;
// using Character.SetupData;
// using GameCore;
// using UnityEngine;
//
// namespace Character.Benedict.Setup
// {
// 	/// <summary>
// 	/// Contains keys that corresponding animator uses. Keys are hashed for performance reasons.
// 	/// </summary>
// 	[Serializable]
// 	public class BenedictAnimatorSetup : AnimatorSetupBase
// 	{
// 		public BenedictAnimatorSetup()
// 		{
// 			Init();
// 		}
//
// 		[Header("Floats:")]
// 		public AnimationStringHash MovementFactor = new AnimationStringHash {StringValue = "movementFactorFloat"};
// 		public AnimationStringHash CrouchFactor = new AnimationStringHash {StringValue = "crouchFactorFloat"};
// 		public AnimationStringHash Grounded = new AnimationStringHash {StringValue = "groundedFloat"};
// 		public AnimationStringHash VelocityX = new AnimationStringHash {StringValue = "xVelocityFloat"};
// 		public AnimationStringHash VelocityY = new AnimationStringHash {StringValue = "yVelocityFloat"};
// 		public AnimationStringHash DashDirection = new AnimationStringHash {StringValue = "dashDirectionFloat"};
// 		public AnimationStringHash IsReloading = new AnimationStringHash {StringValue = "isReloadingFloat"};
// 		
// 		[Header("Ints:")]
// 		public AnimationStringHash DamageId = new AnimationStringHash {StringValue = "damageIdInt"};
//
// 		[Header("Triggers:")]
// 		public AnimationStringHash ReturnToMoving = new AnimationStringHash {StringValue = "returnToMovingTrigger"};
// 		public AnimationStringHash Jump = new AnimationStringHash {StringValue = "jumpTrigger"};
// 		public AnimationStringHash TakeDamage = new AnimationStringHash {StringValue = "takeDamageTrigger"};
// 		public AnimationStringHash Die = new AnimationStringHash {StringValue = "dieTrigger"};
// 		public AnimationStringHash MeleeAttackUpwards = new AnimationStringHash {StringValue = "meleeAttack0Trigger"};
// 		public AnimationStringHash MeleeAttackDownwards = new AnimationStringHash {StringValue = "meleeAttack1Trigger"};
// 		public AnimationStringHash MeleeAttackThrust = new AnimationStringHash {StringValue = "meleeAttack2Trigger"};
// 		public AnimationStringHash MeleeAttackJumpSlashDownwards = new AnimationStringHash {StringValue = "meleeAttack3Trigger"};
// 		public AnimationStringHash ChanneledMeleeAttack = new AnimationStringHash {StringValue = "channeledMeleeAttackTrigger"};
// 		public AnimationStringHash PreAttackPose = new AnimationStringHash {StringValue = "preAttackPoseTrigger"};
// 		public AnimationStringHash Block = new AnimationStringHash {StringValue = "blockTrigger"};
// 		public AnimationStringHash Dodge = new AnimationStringHash {StringValue = "dodgeTrigger"};
// 		public AnimationStringHash Tackle = new AnimationStringHash {StringValue = "tackleTrigger"};
// 		public AnimationStringHash StartReloading = new AnimationStringHash {StringValue = "startReloadingTrigger"};
// 		public AnimationStringHash CatchLedge = new AnimationStringHash {StringValue = "catchLedgeTrigger"};
// 		public AnimationStringHash ClimbLedge = new AnimationStringHash {StringValue = "climbLedgeTrigger"};
// 		public AnimationStringHash ClimbLowLedge = new AnimationStringHash {StringValue = "climbLowLedgeTrigger"};
// 		public AnimationStringHash StandUp = new AnimationStringHash {StringValue = "standUpTrigger"};
// 		public AnimationStringHash RollJump = new AnimationStringHash {StringValue = "rollJumpTrigger"};
// 		public AnimationStringHash PutDownAnchor = new AnimationStringHash { StringValue = "putDownAnchorTrigger" };
// 		public AnimationStringHash PickUpAnchor = new AnimationStringHash { StringValue = "pickUpAnchorTrigger" };
//
//
// 		public override void Init()
// 		{
// 			SetupHashes();
// 		}
//
// 		private void SetupHashes()
// 		{
// 			//	Floats
// 			MovementFactor.SetupHash();
// 			CrouchFactor.SetupHash();
// 			Grounded.SetupHash();
// 			VelocityY.SetupHash();
// 			VelocityX.SetupHash();
// 			DashDirection.SetupHash();
// 			IsReloading.SetupHash();
//
// 			//	Triggers
// 			ReturnToMoving.SetupHash();
// 			Jump.SetupHash();
// 			TakeDamage.SetupHash();
// 			Die.SetupHash();
// 			MeleeAttackUpwards.SetupHash();
// 			MeleeAttackDownwards.SetupHash();
// 			MeleeAttackThrust.SetupHash();
// 			MeleeAttackJumpSlashDownwards.SetupHash();
// 			ChanneledMeleeAttack.SetupHash();
// 			PreAttackPose.SetupHash();
// 			Block.SetupHash();
// 			Dodge.SetupHash();
// 			Tackle.SetupHash();
// 			StartReloading.SetupHash();
// 			CatchLedge.SetupHash();
// 			ClimbLedge.SetupHash();
// 			ClimbLowLedge.SetupHash();
// 			StandUp.SetupHash();
// 			RollJump.SetupHash();
// 			PutDownAnchor.SetupHash();
// 			PickUpAnchor.SetupHash();
//
// 			// Ints
// 			DamageId.SetupHash();
// 		}
// 	}
// }