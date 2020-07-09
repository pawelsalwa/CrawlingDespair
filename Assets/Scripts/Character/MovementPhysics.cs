using System;
using System.Collections.Generic;
using System.Linq;
using Character.Benedict;
using Character.SetupData;
using Tools;
using UnityEngine;

namespace Character
{
	/// <summary>
	/// This class works as API for character movement.
	/// It manages acceleration, gravity, slope walking, steep slope sliding.
	/// </summary>
	public class MovementPhysics
	{
		// public event Action<Vector2> OnGroundedStart;
		//
		// private CharacterController characterController;
		// private BipedPhysicsSetup bipedPhysicsSetup;
		//
		// private Vector2 currentSpeed = Vector2.zero;
		// private Vector2 targetSpeed = Vector2.zero;
		//
		// private Vector2 avgNormalBelow;
		// private Vector2 avgNormalTotal;
		//
		// private readonly List<Vector2> currentNormals = new List<Vector2>();
		// private readonly List<Collider> currentColliders = new List<Collider>();
		// // private Vector2 currentMovement;
		//
		// private IPushable collidedPushable;
		// // private CharacterController collidedCtroler;
		// private CollisionFlags collisionFlags;
		//
		// // private bool jumpRequested = false;
		// // private bool highJumpRequested = false;
		// // private bool motionRequested = false;
		// private bool wasGroundedLastFrame = false;
		// private float desiredX = 0f;
		//
		//
		// public bool IsGrounded => characterController.isGrounded;
		// public Vector2 Velocity => characterController.velocity;
		//
		// private bool WalksDownSlope => avgNormalBelow.x > 0.01f && desiredX > 0f || avgNormalBelow.x < -0.01f && desiredX < 0f;
		// private float AngleToGround => Vector2.Angle(avgNormalBelow, Vector2.up);
		//
		// private bool OnSteepSlope => AngleToGround > bipedPhysicsSetup.minAngleToSlide && (collisionFlags & CollisionFlags.Below) != 0;
		// 	
		// private bool IsBraking => Mathf.Abs(desiredX) < 0.01f;
		//
		// public MovementPhysics(BipedPhysicsSetup bipedPhysicsSetup, CharacterController characterController)
		// {
		// 	this.characterController = characterController;
		// 	this.bipedPhysicsSetup = bipedPhysicsSetup;
		// }
		//
		// public void Jump()
		// {
		// 	if (IsGrounded && !OnSteepSlope)
		// 	{
		// 		// jumpRequested = true;
		// 		currentSpeed.y = targetSpeed.y = bipedPhysicsSetup.jumpSpeed;
		// 	}
		// }
		//
		// public void HighJump()
		// {
		// 	if (IsGrounded && !OnSteepSlope)
		// 	{
		// 		// highJumpRequested = true;
		// 		currentSpeed.y = targetSpeed.y = bipedPhysicsSetup.jumpSpeed * 1.3f;
		// 	}
		// }
		//
		// public void SetCurrentMotion(Vector2 motion)
		// {
		// 	// motionRequested = true;
		// 	SetCurrentX(motion.x);
		// 	SetY(motion.y);
		// }
		//
		// public void SetDesiredX(float val, bool applyInAir = true)
		// {
		// 	if (!applyInAir && !IsGrounded) return;
		// 	desiredX = val;
		// 	// targetSpeed.x = val;
		// }
		//
		// public void SetCurrentX(float val, bool applyInAir = true)
		// {
		// 	if (!applyInAir && !IsGrounded) return;
		// 	desiredX = currentSpeed.x = val;
		// }
		//
		// public void SetY(float val)
		// {
		// 	currentSpeed.y = targetSpeed.y = val;
		// }
		//
		// public void FixedUpdate()
		// {
		// 	RequestControllerMove(currentSpeed * Time.deltaTime);
		// 	ApplyGravity();
		// 	SetMovementVector();
		// 	// ApplyMovementDir();
		// 	AdaptToCollisions();
		// }
		//
		// private void SetMovementVector()
		// {
		// 	// if (jumpRequested)
		// 	// {
		// 	// 	currentSpeed.y = targetSpeed.y = bipedPhysicsSetup.jumpSpeed;
		// 	// 	jumpRequested = false;
		// 	// 	return;
		// 	// }
		// 	// 	
		// 	// if (highJumpRequested)
		// 	// {
		// 	// 	currentSpeed.y = targetSpeed.y = bipedPhysicsSetup.jumpSpeed * 1.3f;
		// 	// 	highJumpRequested = false;
		// 	// 	return;
		// 	// }
		// 	// 	
		// 	// if (motionRequested) // used just to pass one fixed update to not adjust direction on ground
		// 	// {
		// 	// 	motionRequested = false; // should do
		// 	// 	return;
		// 	// }
		// 	
		// 	float acc = 0f;
		// 	if (IsGrounded)
		// 	{
		// 		if (OnSteepSlope)
		// 		{
		// 			acc = Mathf.Abs(avgNormalBelow.x) * bipedPhysicsSetup.slideSteepSlopeFactor;
		// 			targetSpeed = Vector3.Cross(avgNormalBelow, Vector3.forward).normalized; // perpendicullar to normal
		// 			targetSpeed *= avgNormalBelow.x < 0f ? -1f : 1f; // direction to face down slope
		// 			targetSpeed *= bipedPhysicsSetup.slidingMaxSpeed; // speed is based on data
		// 			targetSpeed.y -= Mathf.Abs(bipedPhysicsSetup.constantGravityOnDownSlope); // force y little downwards as we do when walking down slopes
		// 			// acc = IsBraking ? bipedPhysicsSetup.groundBraking : bipedPhysicsSetup.groundAcc;
		// 			// targetSpeed = bipedPhysicsSetup.slidingMaxSpeed * (avgNormalBelow.x < 0f ? -1f : 1f);
		// 			// Debug.DrawLine(characterController.transform.position + Vector3.up / 1.5f, characterController.transform.position + Vector3.up / 1.5f + new Vector3(targetSpeed.x, targetSpeed.y, 0f).normalized, Color.cyan, 1f);
		// 			// Debug.Log($"<color=white>sliding donw slope, cs {currentSpeed}, ts {targetSpeed}, acc { acc}</color>");
		// 		} 
		// 		else if (WalksDownSlope)
		// 		{
		// 			Vector2 dir = Vector3.Cross(avgNormalBelow, Vector3.forward).normalized; // perpendicullar to normal
		// 			dir *= avgNormalBelow.x < 0f ? -1f : 1f; // vector direction matches properly
		// 			dir.Normalize();
		// 			targetSpeed = dir * Mathf.Abs(desiredX);
		// 			targetSpeed.y -= Mathf.Abs(bipedPhysicsSetup.constantGravityOnDownSlope); // force y little downwards
		// 			acc = IsBraking ? bipedPhysicsSetup.groundBraking : bipedPhysicsSetup.groundAcc;
		// 			// Debug.Log($"<color=white>down slope ts {targetSpeed}, dir {dir}</color>");
		// 			// Debug.DrawLine(characterController.transform.position + Vector3.up / 1.4f, characterController.transform.position + Vector3.up / 1.4f + new Vector3(dir.x, dir.y, 0f).normalized, Color.green, 1f);
		// 		}
		// 		else
		// 		{
		// 			acc = IsBraking ? bipedPhysicsSetup.groundBraking : bipedPhysicsSetup.groundAcc;
		// 			targetSpeed = new Vector2(desiredX, -Mathf.Abs(bipedPhysicsSetup.constantGravityOnDownSlope));
		// 		}				
		// 	}
		// 	else
		// 	{
		// 		acc = IsBraking ? bipedPhysicsSetup.airBraking : bipedPhysicsSetup.airAcc;
		// 		targetSpeed.x = desiredX;
		// 		// Debug.Log($"<color=white>acc = {acc}, air braking : {IsBraking}</color>");
		// 	}
		//
		// 	// currentSpeed = targetSpeed.normalized * currentSpeed.magnitude;
		// 	// currentSpeed = Vector2.rotate
		// 	currentSpeed = Vector2.MoveTowards(currentSpeed, targetSpeed, acc * Time.deltaTime);
		// 	// currentSpeed.x = Mathf.MoveTowards(currentSpeed.x, targetSpeed.x, acc * Time.deltaTime);
		//
		// 	// currentSpeed.y = targetSpeed.y; // acceleration applies only vertically
		// 	// currentSpeed = targetSpeed;
		// }
		//
		// private void ApplyGravity()
		// {
		// 	if (IsGrounded) return;
		// 	currentSpeed.y -= 9.81f * Time.deltaTime;
		// 	targetSpeed.y -= 9.81f * Time.deltaTime;
		// 	// targetSpeed = bipedPhysicsSetup.maxFallingSpeed;
		// }
		//
		// public void RequestControllerMove(Vector2 motion)
		// {
		// 	currentNormals.Clear();
		// 	currentColliders.Clear();
		// 	collidedPushable = null;
		// 	//if (collidedCtroler != null)
		// 	//Physics.IgnoreCollision(collidedCtroler, characterController, false);
		// 	//collidedCtroler = null;
		// 	
		// 	var velcache = Velocity;
		// 	if (characterController.enabled) //we turn off controller sometimes so this avoids warnings
		// 		collisionFlags = characterController.Move(motion);
		// 	// Debug.DrawLine(characterController.transform.position + Vector3.up / 1.1f, characterController.transform.position + Vector3.up / 1.1f + new Vector3(motion.x, motion.y, 0f).normalized, Color.red, 1f);
		// 	CalculateAvgNormalsAfterMove();
		// 	if (!wasGroundedLastFrame && IsGrounded)
		// 	{
		// 		// Debug.Log($"<color=white>jebnal o ziemie</color>");
		// 		OnGroundedStart?.Invoke(velcache);
		// 		// currentSpeed.y = targetSpeed.y = -0.1f;
		// 	}
		// 	
		// 	if (wasGroundedLastFrame && !IsGrounded)
		// 	{
		// 		// Debug.Log($"<color=blue>off gorund</color>");
		// 		// OnGroundedStart?.Invoke(currentSpeed);
		// 	}
		// 	wasGroundedLastFrame = IsGrounded;
		// }
		//
		// private void AdaptToCollisions()
		// {
		// 	if (collidedPushable == null)
		// 	{
		// 		if ((collisionFlags & CollisionFlags.Above) != 0 && currentSpeed.y > 0f) // jebniecie glowa o sufit
		// 		{
		// 			if (currentNormals.Any(n => Mathf.Abs(n.x) > 0.2f)) // jebniecie glowa o odpowiednio krzywy sufit
		// 				currentSpeed.x = targetSpeed.x = 0f;
		// 			
		// 			currentSpeed.y = targetSpeed.y = -0.001f;
		// 		}
		// 		
		// 		if (collisionFlags == CollisionFlags.Sides && avgNormalTotal.x > 0.7) 
		// 			currentSpeed.x = 0f; // avg normal uzyty bo jest bug ze collision flags zwraca sides na slopach ;(
		// 	}
		// 	else
		// 	{
		// 		if (collisionFlags == CollisionFlags.Below && currentColliders.Count == 0)//bot pod nami
		// 		{
		//
		// 			//Physics.IgnoreCollision(collidedCtroler, characterController);
		// 			//characterController.enabled = false;
		// 			//characterController.transform.position -= Vector3.down * bipedPhysicsSetup.moveDownMultiplierOnHead;
		// 			//characterController.enabled = true;
		// 			// 	Debug.Log($"<color=red>bot pod nami</color>");
		// 			// 	characterController.center = characterController.center * bipedPhysicsSetup.centermultiplierOnHead;
		// 			// 	characterController.height = characterController.height * bipedPhysicsSetup.heightMultipleirOnHead;
		// 			// 	characterController.Move(Vector3.down * bipedPhysicsSetup.moveDownMultiplierOnHead);
		// 		}
		// 		
		// 			
		// 		
		// 		if ((collidedPushable.Position.x > characterController.transform.position.x && currentSpeed.x > 0f ||
		// 		     collidedPushable.Position.x < characterController.transform.position.x && currentSpeed.x < 0f) 
		// 		    )//&& currentSpeed.y > -0.2f) // case of jumping towards pushable, and rising
		// 		{
		// 			// Debug.Log($"<color=cyan> pushing other, flags: {collisionFlags}</color>");
		// 			collidedPushable?.PushX(currentSpeed.x * bipedPhysicsSetup.pushOtherControllerVelocityFactor); // pchanie botow horizontal
		// 		}
		// 		else
		// 		{
		// 			// Debug.Log($"<color=magenta> pushing other backwards, flags: {collisionFlags}</color>");
		// 			// collidedPushable?.PushX(-currentSpeed.x * bipedPhysicsSetup.pushOtherControllerVelocityFactor); // pchanie botow horizontal	
		// 		}
		// 		
		// 		if (currentSpeed.y < 0f && collidedPushable.Position.y < characterController.transform.position.y) // case of falling down onto bots head
		// 		{
		// 			// 	Debug.Log($"<color=gray> pushing other on head, flags: {collisionFlags}</color>");
		// 			// 	var speedOfBoth = collidedPushable.Position.x < characterController.transform.position.x ? bipedPhysicsSetup.xSpeedOnHead : -bipedPhysicsSetup.xSpeedOnHead;
		// 			// 	currentSpeed.x = speedOfBoth;
		// 			// 	currentSpeed.y -= bipedPhysicsSetup.ySpeedOnHead;
		// 			// 	characterController.Move(new Vector2(speedOfBoth, -Mathf.Abs(bipedPhysicsSetup.ySpeedOnHead)) * Time.deltaTime);
		// 			// 	collidedPushable.PushX(-speedOfBoth * bipedPhysicsSetup.pushOtherControllerVelocityFactor);
		// 		}
		// 	}
		// 	
		// 	// if ((collisionFlags & CollisionFlags.Sides) != 0 && currentNormals.Any(n => Mathf.Abs(n.x) > 0.9f) && currentSpeed.y > 0.01f) currentSpeed = targetSpeed = Vector2.zero; // kolizja w powietrzu z pionowa sciana stopuje caly movement
		//
		// 	if (collidedPushable != null)
		// 	{
		// 	}
		// 	// if ((collisionFlags & CollisionFlags.Sides) != 0)
		// 	// else if ((collisionFlags & CollisionFlags.Below) != 0 && collidedPushable != null)
		// 	// {
		// 		// var speedOfBoth = collidedPushable.Position.x < characterController.transform.position.x ? bipedPhysicsSetup.xSpeedOnHead : -bipedPhysicsSetup.xSpeedOnHead;
		// 		// currentSpeed.x = speedOfBoth;
		// 		// currentSpeed.y -= bipedPhysicsSetup.ySpeedOnHead;
		// 		// characterController.Move(new Vector2(speedOfBoth, -Mathf.Abs(bipedPhysicsSetup.ySpeedOnHead)) * Time.deltaTime);
		// 		// collidedPushable.PushX(-speedOfBoth * bipedPhysicsSetup.pushOtherControllerVelocityFactor);
		// 	// }
		// }
		//
		// public void OnControllerColliderHit(ControllerColliderHit info)
		// {
		// 	var other = info.gameObject.GetComponent<IPushable>(); // attention - bene nie jest pushable! tylko boty (narazie przynajmniej)
		// 	if (other == null) OnEnviroHit();
		// 	else OnPushableHit();
		//
		// 	if (info.gameObject.GetComponent<CharacterBenedict>() != null)
		// 		currentSpeed.x = 0f; // hax na hook pulla
		// 	
		// 	void OnPushableHit()
		// 	{
		// 		collidedPushable = other;
		// 		// collidedCtroler = info.gameObject.GetComponent<CharacterController>();
		// 	}
		//
		// 	void OnEnviroHit()
		// 	{
		// 		currentColliders.Add(info.collider);
		// 		currentNormals.Add(info.normal);
		// 	}
		// 	
		// }
		//
		// public void PushX(float val)
		// {
		// 	characterController.Move(new Vector2(val, 0f) * Time.deltaTime);
		// }
		//
		// private void CalculateAvgNormalsAfterMove()
		// {
		// 	avgNormalTotal = avgNormalBelow = currentNormals.Count == 0 ? Vector2.up : Vector2.zero;
		// 	foreach (var normal in currentNormals)
		// 	{
		// 		avgNormalTotal += new Vector2(normal.x, normal.y);
		// 		if (normal.y > 0.1f)
		// 			avgNormalBelow += new Vector2(normal.x, normal.y);
		// 	}
		//
		// 	avgNormalBelow.Normalize();
		// 	avgNormalTotal.Normalize();
		// 	// Debug.DrawLine(characterController.transform.position + Vector3.up, characterController.transform.position + Vector3.up + new Vector3(avgNormal.x, avgNormal.y, 0f), Color.red, 1f);
		// }
	}
}