using System;
using UnityEngine;

namespace Character.SetupData
{
	[Serializable]
	public class CharacterAimingSetup
	{
		[Tooltip("Time that character needs to get into full aiming pose. Smoothness is applied.")]
		public float aimDuration = 1f;
		
		[Tooltip("Time that character needs to be able to shoot after aiming has reached full.")]
		public float AimingDurationToEnableShoot = 0.5f;
	}
}