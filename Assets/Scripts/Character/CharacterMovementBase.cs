using System;
using Character.SetupData;
using UnityEngine;

namespace Character
{
	/// <summary>
	/// Implement this and add logic to control <see cref="characterController"/> to handle character motions.
	/// </summary>
	public abstract class CharacterMovementBase
	{
		// public event Action<Vector2> OnGroundedStart;

		protected readonly CharacterController characterController;
		protected readonly MovementSetupBase movementSetupBase;
		protected readonly CharacterTurning characterTurning;

		protected CharacterMovementBase(CharacterController characterController, MovementSetupBase movementSetupBase)
		{
			this.characterController = characterController;
			this.movementSetupBase = movementSetupBase;
			this.characterTurning = new CharacterTurning(characterController.transform, movementSetupBase);
		}

		public void Update()
		{
			characterTurning.Update();
		}

		public virtual void FixedUpdate()
		{
		}

		public virtual void OnControllerColliderHit(ControllerColliderHit info)
		{
		}

		public abstract void StopWalking();

		public void MoveByInput(Vector2 inputVal, bool teddyInputRun)
		{
			Vector2 movement = Rotate(inputVal, characterController.transform.eulerAngles.y).normalized;
			movement *= teddyInputRun ? movementSetupBase.RunSpeed : movementSetupBase.WalkSpeed;
			RequestControllerMove(movement);
		}

		private void RequestControllerMove(Vector2 motion)
		{
			Vector3 motion3d = new Vector3(motion.x, 0f, motion.y);
			characterController.Move(motion3d * Time.deltaTime);
		}

		Vector2 Rotate(Vector2 aPoint, float aDegree)
		{
			float rad = aDegree * Mathf.Deg2Rad;
			float s = Mathf.Sin(rad);
			float c = Mathf.Cos(rad);
			return new Vector2(
				aPoint.x * c + aPoint.y * s,
				aPoint.y * c - aPoint.x * s);
		}
	}
}