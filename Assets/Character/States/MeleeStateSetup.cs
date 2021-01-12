﻿using System;
using Pawn;

namespace Character.States
{
	[Serializable]
	public class MeleeStateSetup : StateSetup
	{
		public float TransitionToNextComboExitTime = 1f;
		public float ComboWindowStart = 0;
		public float ComboWindowEnd = 2;
		public float DealDmgWindowStart  = 0.15f;
		public float DealDmgWindowEnd  = 0.35f;
		public float TrailStart = 0.1f;
		public float TrailEnd = 0.4f;
	}
}