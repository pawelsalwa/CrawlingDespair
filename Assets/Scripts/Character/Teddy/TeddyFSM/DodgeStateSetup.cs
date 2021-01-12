using System;
using Character.FSMSetupData;

namespace Character.Teddy.TeddyFSM
{
	[Serializable]
	public class DodgeStateSetup : StateSetupBase
	{
		public float EnableAttackTreshold = 0.2f;
	}
}