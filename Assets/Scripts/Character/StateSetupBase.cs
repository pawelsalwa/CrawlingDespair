using System;
using UnityEngine;

namespace Character.FSMSetupData
{
	[Serializable]
	public class StateSetupBase
	{
		[Tooltip("Should this state be active finitely?")]
		public bool HasExitTime = false;
		
		[Tooltip("Duration of this state in seconds if 'HasExitTime' is set to true. Transition target can be overriden through virtual property: CharacterStateBase.DefaultNextState. By default target is MovingState.")]
		public float StateDuration = 1f;
	}
}