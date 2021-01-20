using System;
using UnityEngine;

namespace Pawn
{
	[Serializable]
	public class Input
	{
		public float LookAtAngle;
		public Vector2 Movement;
		public bool Attack;
		public bool Dodge;
		public bool Run;

		public void ResetFields()
		{
			Attack = Dodge = Run = false;
			Movement = Vector2.zero;
			// LookAtAngle = 0;
		}
	}
}