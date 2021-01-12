using Pawn.Setup;
using UnityEngine;

namespace Pawn
{
	/// <summary>
	/// Implement this and add logic to control <see cref="characterController"/> to handle character motions.
	/// </summary>
	public class Movement
	{
		// public event Action<Vector2> OnGroundedStart;

		protected readonly CharacterController characterController;
		protected readonly MovementSetup setup;
		protected readonly PawnTurning pawnTurning;

		/// <summary> This can be used for anim, its local space velocity </summary>
		public Vector2 InternalCharacterVelocity { get; private set; }

		public Movement(CharacterController characterController, MovementSetup setup)
		{
			this.characterController = characterController;
			this.setup = setup;
			this.pawnTurning = new PawnTurning(characterController.transform, setup);
		}

		public void Update()
		{
			pawnTurning.Update();
		}

		public void MoveByInput(Vector2 inputVal, bool teddyInputRun)
		{
			inputVal *= teddyInputRun ? setup.RunSpeed : setup.WalkSpeed;
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

		public void OnAnimatorMove(Vector3 animatorDeltaPosition)
		{
			// if (animatorDeltaPosition.x > 0.01f || animatorDeltaPosition.z > 0.01f)
				// Debug.Log($"<color=white>anim delta pos: x : {animatorDeltaPosition.x}, z: {animatorDeltaPosition.z} </color>");
			// Vector2 movement = Rotate(new Vector2(animatorDeltaPosition.x, animatorDeltaPosition.z), characterController.transform.eulerAngles.y);
			characterController.Move(new Vector3(animatorDeltaPosition.x, 0f, animatorDeltaPosition.z));
		}
	}
}