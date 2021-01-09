using System;
using Character.SetupData;
using UnityEngine;

namespace Character
{
	/// <summary>
	/// Implement this and add logic to control <see cref="characterController"/> to handle character motions.
	/// </summary>
	public class CharacterMovementBase
	{
		// public event Action<Vector2> OnGroundedStart;

		protected readonly CharacterController characterController;
		protected readonly MovementSetupBase movementSetupBase;
		protected readonly CharacterTurning characterTurning;

		/// <summary> This can be used for anim, its local space velocity </summary>
		public Vector2 InternalCharacterVelocity { get; private set; }

		public CharacterMovementBase(CharacterController characterController, MovementSetupBase movementSetupBase)
		{
			this.characterController = characterController;
			this.movementSetupBase = movementSetupBase;
			this.characterTurning = new CharacterTurning(characterController.transform, movementSetupBase);
		}

		public void Update()
		{
			characterTurning.Update();
		}

		public void MoveByInput(Vector2 inputVal, bool teddyInputRun)
		{
			inputVal *= teddyInputRun ? movementSetupBase.RunSpeed : movementSetupBase.WalkSpeed;
			InternalCharacterVelocity = inputVal;
			Vector2 movement = Rotate(inputVal, characterController.transform.eulerAngles.y);
			RequestControllerMove(movement);
		}

		private void RequestControllerMove(Vector2 motion)
		{
			Vector3 motion3d = new Vector3(motion.x, 0f, motion.y) * Time.deltaTime;
			characterController.Move(motion3d);
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

		/// <summary> imeediately calls move on controller </summary>
		public void ForceMoveForward(float value)
		{
			Vector2 movement = Rotate(Vector2.up * value, characterController.transform.eulerAngles.y);
			characterController.Move(new Vector3(movement.x, 0, movement.y));
		}

		public void ForceMovement(Vector3 animatorDeltaPosition)
		{
			characterController.Move(new Vector3(animatorDeltaPosition.x, 0, animatorDeltaPosition.y));
		}
	}
}