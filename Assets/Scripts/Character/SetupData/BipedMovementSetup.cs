// using System;
// using UnityEngine;
//
// namespace Character.SetupData
// {
// 	[Serializable]
// 	public class BipedMovementSetup : MovementSetupBase
// 	{
// 		[Header("Moving:")]
// 		[Tooltip("Regular walk speed in Unity units per second.")]
// 		public float WalkSpeed = 5f;
// 		[Tooltip("Speed when character is crouching in Unity units per second.")]
// 		public float CrouchingSpeed = 3f;
// 		[Tooltip("Run speed in Unity units per second.")]
// 		public float RunSpeed = 8f;
// 		
// 		// [Header("Jumping:")] jumping is in physics
// 		// [Tooltip("Vertical speed added to character when jumping.")]
// 		// public float JumpSpeed = 4f;
// 		[Tooltip("Speed added to character when hooking. Direction is determined by the hook.")]
// 		public float HookJumpSpeed = 8f;
// 		// [Tooltip("Speed added to character when Benedict pulls him with hook. Direction is towards Benedict.")]
// 		// public float HookPullSpeed = 8f;
// 		[Tooltip("Speed added to character when Benedict performs hook kneel on it. Direction is hardcoded towards ground.")]
// 		public float HookKneelSpeed = 6f;
// 		
// 		// [Header("Misc:")]
// 		// [Tooltip("CharacterController height set when character is ordered to crouch.")]
// 		// public float CrouchingHeight = 1.5f;
// 		// [Tooltip("CharacterController height set when character is not crouching.")]
// 		// public float WalkingHeight = 1.8f;
// 		// [Tooltip("CharacterController height set when character is hit with kneel effect(benedict's attack downwards for instance).")]
// 		// public float KneelHeight = 0.9f;
// 		// [Tooltip("CharacterController height set when character is hit with knockback effect.")]
// 		// public float KnockbackHeight = 0.2f;
// 		// [Tooltip("CharacterController height set when character is tackling.")]
// 		// public float TackleHeight = 0.9f;
// 		
// 		// [Tooltip("Vertical speed in Units per Second when character is ordered to turn to face moving direction.")]
// 		// public float MinSpeedToTurn = 0.35f;
//
// 		// [Tooltip("Minimum velocity needed to medium damage entity when falling.")] // moved to health setup
// 		// public float VelocityForMediumDamageWhenFalling = -4f;
// 		//
// 		// [Tooltip("Minimum velocity needed to hard damage entity when falling.")]
// 		// public float VelocityForHardDamageWhenFalling = -7f;
//
// 		[Range(0f, 2f)]
// 		[Tooltip("Duration of turning from left to right and vice versa.")]
// 		public float TurnTimeout = 0.5f;
// 		
// 		[Tooltip("Offset added to capsule height so can be higher (to help demon take projectile dmg for example).")]
// 		public float CapsuleHeightOffset = 0.2f;
//
// 		[Tooltip("Used to find distance to ground with raycast")]
// 		public LayerMask groundLayerMask;
//
// 		[Tooltip("Used to not change anim into air when we are slightly above. Useful for stairs.")]
// 		public float distForAnimToConsiderGrounded = 0.4f;
// 		
// 		[Header("Physics:")]
// 		public BipedPhysicsSetup physicsSetup;
//
//
//
// 	}
// }