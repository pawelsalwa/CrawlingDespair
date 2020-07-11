﻿using Character.SetupData;
using ExtensionMethods;
using ScriptableObjects;
using UnityEngine;

namespace Character
{
	public class CharacterTurning
	{
		private readonly Transform transform;
		private readonly MovementSetupBase movementSetupBase;

		private float targetRotationY;

		public CharacterTurning(Transform transform, MovementSetupBase movementSetupBase)
		{
			this.transform = transform;
			this.movementSetupBase = movementSetupBase;
		}

		public void Update()
		{
			targetRotationY = movementSetupBase.cameraRotationY.Value;
			var angles = transform.eulerAngles;
			var eulerAngles = angles;
			var currentRotY = Mathf.LerpAngle(eulerAngles.y, targetRotationY, movementSetupBase.TurningFactor);

			// Debug.Log($"<color=white>current: {angles}, new: {eulerAngles}</color>");
			eulerAngles = new Vector3(eulerAngles.x, currentRotY, eulerAngles.z);
			angles = eulerAngles;
			transform.eulerAngles = angles;
		}
	}
}