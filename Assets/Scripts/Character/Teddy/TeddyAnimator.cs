using Character.SetupData;
using UnityEngine;

namespace Character.Teddy
{
	public class TeddyAnimator : CharacterAnimatorBase
	{
		private TeddyAnimatorSetup teddyAnimatorSetup => data as TeddyAnimatorSetup;

		public TeddyAnimator(Animator animator, TeddyAnimatorSetup data) : base(animator, data)
		{
		}

		private static readonly int melee1 = Animator.StringToHash("Melee1");
		private static readonly int movement = Animator.StringToHash("Movement");
		public float movingTransDur = 0.1f;

		public override void Update(AnimatorUpdateDataBase animatorUpdateDataBase)
		{
			TeddyAnimatorUpdateData teddyAnimatorUpdateData = (TeddyAnimatorUpdateData) animatorUpdateDataBase;
			if (teddyAnimatorUpdateData == null)
			{
				Debug.LogError($"<color=red> Type mismatch. Animator should be updated with proper Type of inheritance layer.</color>");
				return;
			}

			SetMovement(teddyAnimatorUpdateData.velocity, teddyAnimatorUpdateData.run);
		}

		private void SetMovement(Vector2 velocity, bool run)
		{
			SetFloat(teddyAnimatorSetup.XVelFloat, velocity.x, teddyAnimatorSetup.MovementDampTime);
			SetFloat(teddyAnimatorSetup.YVelFloat, velocity.y, teddyAnimatorSetup.MovementDampTime);
			SetFloat(teddyAnimatorSetup.RunFloat, run ? 1f : 0f, teddyAnimatorSetup.MovementDampTime);
		}

		public void Attack() => Transition(melee1);
		public void ReturnToDefault() => Transition(movement);

		private void Transition(int targetStateHash, float duration = 0.1f, float targetAnimOffset = 0f)
		{
			// var xd = animator.GetCurrentAnimatorStateInfo(0);
			animator.CrossFade(targetStateHash, duration, 0, targetAnimOffset);//xd.normalizedTime);
		}


		public void SetTrigger(string value) => animator.SetTrigger(value);
		public void SetFloat(string name, float value) => animator.SetFloat(name, value);
		public void SetFloat(string name, float value, float dampTime) => animator.SetFloat(name, value, dampTime,Time.deltaTime);
	}
}