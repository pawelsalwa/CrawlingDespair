using System;
using UnityEngine;

namespace Pawn
{
	[Serializable]
	public class Refs
	{
		public bool FsmDebugs = false;
		public TrailRenderer Trail;
		public bool overrideInput = false;
		public Input DebugInput;
	}
}