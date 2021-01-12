using System;
using UnityEngine;

namespace Character.Teddy
{
	[Serializable]
	public class TeddyPrefabRefs
	{
		public bool StateMachineDebugs = false;
		public GameObject Trail;
		public bool overrideInput = false;
		public Input DebugInput;
	}
}