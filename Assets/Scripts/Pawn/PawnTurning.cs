using Pawn.Setup;
using UnityEngine;

namespace Pawn
{
	public class PawnTurning
	{
		private readonly Transform transform;
		private readonly MovementSetup movementSetupBase;

		private float targetRotationY;

		public PawnTurning(Transform transform, MovementSetup movementSetupBase)
		{
			this.transform = transform;
			this.movementSetupBase = movementSetupBase;
		}

		public void Update()
		{
			targetRotationY = MainCamera.gameplayCamera.transform.rotation.eulerAngles.y;

			var angles = transform.eulerAngles;
			var eulerAngles = angles;
			var currentRotY = Mathf.LerpAngle(eulerAngles.y, targetRotationY, movementSetupBase.TurningFactor * Time.deltaTime);

			// Debug.Log($"<color=white>current: {angles}, new: {eulerAngles}</color>");
			eulerAngles = new Vector3(eulerAngles.x, currentRotY, eulerAngles.z);
			angles = eulerAngles;
			transform.eulerAngles = angles;
		}
	}
}