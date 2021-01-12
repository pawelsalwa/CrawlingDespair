using System;
using Character.SetupData;
using UnityEngine.Serialization;

namespace Character.Teddy
{
	[Serializable]
	public class TeddyAnimatorSetup : AnimatorSetupBase
	{
		public override void Init()
		{
			// could be needed to setup hashes
		}

		// public string XVelFloat = "xVelFloat";
		// public string YVelFloat = "yVelFloat";
		// public string RunFloat = "runFloat";
		// public string Attack = "attackTrigger";
		// public string ReturnToDefault = "returnToDefaultTrigger";
		
		public float MovementDampTime = 0.1f;
		[FormerlySerializedAs("tmpAnimOffset")] public float melee1Offset = 0.2f;
		public float dodgeOffset = 0.2f;
		public float MovingTransDur = 0.2f;
	}
}