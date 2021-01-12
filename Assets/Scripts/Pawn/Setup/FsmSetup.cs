﻿using System;

namespace Pawn.Setup
{
	[Serializable]
	public class FsmSetup
	{
		public StateSetup moving;
		public DodgeSetup dodge;
		public AttackSetup attack0;
		public AttackSetup attack1;
	}
}