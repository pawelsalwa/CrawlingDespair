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

		protected CharacterMovementBase(CharacterController characterController, MovementSetupBase movementSetupBase)
		{
			this.characterController = characterController;
			this.movementSetupBase = movementSetupBase;
		}

		public virtual void FixedUpdate()
		{
		}

		public virtual void OnControllerColliderHit(ControllerColliderHit info)
		{
		}

		public abstract void StopWalking();

		public void MoveByInput(Vector2 inputVal)
		{
			RequestControllerMove(inputVal * movementSetupBase.Speed);
		}

		private void RequestControllerMove(Vector2 motion)
		{
			Vector3 motion3d = new Vector3(motion.x, 0f, motion.y);
			characterController.Move(motion3d * Time.deltaTime);
		}
	}
}