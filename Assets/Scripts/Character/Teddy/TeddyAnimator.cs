using UnityEngine;

namespace Character.Teddy
{
	public class TeddyAnimator : CharacterAnimatorBase
	{
		public TeddyAnimator(Animator animator) : base(animator)
		{
		}

		public override void Update(AnimatorUpdateDataBase animatorUpdateDataBase)
		{
			TeddyAnimatorUpdateData teddyAnimatorUpdateData = (TeddyAnimatorUpdateData) animatorUpdateDataBase;
			if (teddyAnimatorUpdateData == null)
			{
				Debug.LogError($"<color=red> Type mismatch. Animator should be updated with proper Type of inheritance layer.</color>");
				return;
			}
		}
	}
}