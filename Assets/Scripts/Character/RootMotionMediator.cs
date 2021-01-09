using System;
using Character.Teddy;
using UnityEngine;

namespace Character
{
	/// <summary>
	/// takes root motion from animator and forwards it 
	/// </summary>
	public class RootMotionMediator : MonoBehaviour
	{
		public CharacterTeddy teddy;
		
		private void OnAnimatorMove()
		{
			// teddy.OnAnimatorMove();
		}
	}
}