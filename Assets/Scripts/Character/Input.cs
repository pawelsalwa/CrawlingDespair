using System;
using UnityEngine;

namespace Character
{
	[Serializable]
	public class Input
	{
		public Vector2 Movement;
		public bool Attack;
		public bool Dodge;
		public bool Run;
	}
}