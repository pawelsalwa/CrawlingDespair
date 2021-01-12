using System;
using ScriptableObjects;
using UnityEngine;

namespace Character.SetupData
{
	[Serializable]
	public class MovementSetupBase
	{
		public float WalkSpeed = 2.5f;
		public float RunSpeed = 4.5f;
		public float TurningFactor = 0.3f;
	}
}