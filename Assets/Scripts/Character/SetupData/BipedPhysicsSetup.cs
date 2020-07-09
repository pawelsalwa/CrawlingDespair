// using System;
// using UnityEngine;
// using static Tools.TooltipsStrings;
//
// namespace Character.SetupData
// {
// 	[Serializable]
// 	public class BipedPhysicsSetup
// 	{
// 		[Tooltip("Movement along steep slopes is multiplied by this value. It's essentially acceleration along steep slope.")]
// 		public float slideSteepSlopeFactor = 1f;
// 		[Tooltip("When angle of slope under character exceeds this value, he will start sliding.")]
// 		public float minAngleToSlide = 45f;
// 		[Tooltip("Horizontal acceleration when ordered to move on ground.")]
// 		public float groundAcc = 3f;
// 		[Tooltip("Horizontal acceleration when ordered to move in air.")]
// 		public float airAcc = 3f;
// 		[Tooltip("When not ordered to move, this is horizontal brake applied every frame to lower velocity when grounded.")]
// 		public float groundBraking = 1f;
// 		[Tooltip("When not ordered to move, this is horizontal brake applied every frame to lower velocity when in air.")]
// 		public float airBraking = 1f;
// 		[Tooltip("Vertical speed applied for one frame when jump is requested.")]
// 		public float jumpSpeed = 7f;
// 		[Tooltip("Applied when walking down the slope. It helps to stick character to the ground but might force too quick falldown from platforms.")]
// 		public float constantGravityOnDownSlope = 0.1f;
// 		[Tooltip("When pushing other character controller, horizontal speed is multiplied by this value. Can be used to prevent movement glittering.")]
// 		public float pushOtherControllerVelocityFactor = 0.7f;
// 		[Tooltip("Horizontal speed applied when on head of other character to force falldown.")]
// 		public float xSpeedOnHead = 1;
// 		[Tooltip("Vertical speed applied when on head of other character to force falldown.")]
// 		public float ySpeedOnHead = 1;
//
// 		[Tooltip("to trigger breakpoints")]
// 		public bool debugMode = false;
//
// 		[Tooltip("When accelerating during sliding, speed cant excess this.")]
// 		public float slidingMaxSpeed = 4f;
//
// 		[Tooltip("Max falling speed, y.")]
// 		public float maxFallingSpeed = 30f;
//
// 		// public float centermultiplierOnHead = 0.8f;
// 		// public float heightMultipleirOnHead = 1.2f;
// 		public float moveDownMultiplierOnHead = 0.4f;
//
// 	}
// }