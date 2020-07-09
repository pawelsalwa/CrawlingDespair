using System;
// using Scriptables.BasicDataTypes;
using Tools;
using UnityEngine;

namespace Character.SetupData
{
	[Serializable]
	public class CharacterHealthSetup
	{
		public bool EnableDebugLog = false;

		[Space]
		public int MaxHP = 3;
		public float VelocityForMediumDamageWhenFalling = 12f;
		public float VelocityForHardDamageWhenFalling = 16f;
	}
}