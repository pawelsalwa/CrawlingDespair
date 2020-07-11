

using Character.SetupData;
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
		protected readonly AnimatorSetupBase data;

		protected CharacterAnimatorBase(Animator animator,  AnimatorSetupBase data)
		{
			this.animator = animator;
			this.data = data;
		}

		public abstract void Update(AnimatorUpdateDataBase animatorUpdateDataBase);
	}
}