using System;
using Character.States;

namespace Pawn
{
	[Serializable]
	public class FsmSetup
	{
		public StateSetup moving;
		public DodgeStateSetup dodge;
		public MeleeStateSetup melee0;
		public MeleeStateSetup melee1;
	}
}