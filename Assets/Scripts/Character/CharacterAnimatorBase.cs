

using Character.Teddy;
using UnityEngine;

namespace Character
{
	/// <summary>
	/// Wrapper for UnityEngine.Animator to set its parameters.
	/// </summary>
	public abstract class CharacterAnimatorBase
	{
		protected readonly Animator animator;

		protected CharacterAnimatorBase(Animator animator)
		{
			this.animator = animator;
		}

		public abstract void Update(AnimatorUpdateDataBase animatorUpdateDataBase);
	}
}