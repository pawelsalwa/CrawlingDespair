using Character.SetupData;
using UnityEngine;

namespace Character.Teddy
{
	public class TeddyAnimator
	{
		private readonly Animator animator;
		private readonly TeddyAnimatorSetup teddyAnimatorSetup;

		public TeddyAnimator(Animator animator, TeddyAnimatorSetup data)
		{
			this.animator = animator;
			teddyAnimatorSetup = data;
		}

		private static readonly int melee0 = Animator.StringToHash("Melee0");
		private static readonly int melee1 = Animator.StringToHash("Melee1");
		private static readonly int dodge = Animator.StringToHash("Dodge");
		private static readonly int movement = Animator.StringToHash("Movement");
		
		private static readonly int xVelFloat = Animator.StringToHash("xVelFloat");
		private static readonly int yVelFloat = Animator.StringToHash("yVelFloat");
		private static readonly int runFloat = Animator.StringToHash("runFloat");
		
		private static readonly int xDodgeDir = Animator.StringToHash("xDodgeDir");
		private static readonly int yDodgeDir = Animator.StringToHash("yDodgeDir");
		
		public float movingTransDur = 0.1f;

		public void Update(Vector2 velocity, bool run)
		{

			SetMovement(velocity, run);
		}

		private void SetMovement(Vector2 velocity, bool run)
		{
			SetFloat(xVelFloat, velocity.x, teddyAnimatorSetup.MovementDampTime);
			SetFloat(yVelFloat, velocity.y, teddyAnimatorSetup.MovementDampTime);
			SetFloat(runFloat, run ? 1f : 0f, teddyAnimatorSetup.MovementDampTime);
		}

		public void Melee0() => Transition(melee0);
		public void Dodge(Vector2 dir)
		{
			SetFloat(xDodgeDir, dir.x);
			SetFloat(yDodgeDir, dir.y);
			Transition(dodge, targetAnimOffset: teddyAnimatorSetup.dodgeOffset);
		}

		public void Melee1() => Transition(melee1, targetAnimOffset: teddyAnimatorSetup.melee1Offset);
		public void ReturnToDefault() => Transition(movement, teddyAnimatorSetup.MovingTransDur);
		private void Transition(int targetStateHash, float duration = 0.1f, float targetAnimOffset = 0f) => animator.CrossFade(targetStateHash, duration, 0, targetAnimOffset);
		
		private void SetFloat(int floatHash, float value) => animator.SetFloat(floatHash, value);
		private void SetFloat(int floatHash, float value, float dampTime) => animator.SetFloat(floatHash, value, dampTime,Time.deltaTime);

	}
}