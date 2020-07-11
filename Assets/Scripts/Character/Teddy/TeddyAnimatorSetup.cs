﻿using System;
using Character.SetupData;

namespace Character.Teddy
{
	[Serializable]
	public class TeddyAnimatorSetup : AnimatorSetupBase
	{
		public override void Init()
		{
			// could be needed to setup hashes
		}

		public string XVelFloat = "xVelFloat";
		public string YVelFloat = "yVelFloat";
		public string Attack = "attackTrigger";
		
		public float MovementDampTime = 0.1f;
	}
}