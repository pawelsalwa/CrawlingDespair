using System;
using Character.Setup;

namespace Character
{
	[Serializable]
	public class DodgeSetup : StateSetup
	{
		public float EnableAttackTreshold = 0.2f;
	}
}