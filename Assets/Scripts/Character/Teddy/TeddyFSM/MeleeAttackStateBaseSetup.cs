using System;
using Character.FSMSetupData;
using UnityEngine;

namespace Character.Teddy.TeddyFSM
{
	[Serializable]
	public class MeleeAttackStateBaseSetup : StateSetupBase
	{
		public float TransitionToNextComboExitTime = 1f;
		public float ComboWindowStart = 0;
		public float ComboWindowEnd = 2;
		public float DealDmgWindowStart  = 0.15f;
		public float DealDmgWindowEnd  = 0.35f;
		// public float MovingDistance = 0.5f;
		// public AnimationCurve MovingCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
	}
}