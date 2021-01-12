using UnityEngine;

namespace Pawn
{
	public class PawnAnimator
	{
		private readonly Animator animator;
		private readonly AnimatorSetup animatorSetup;

		public PawnAnimator(Animator animator, AnimatorSetup data)
		{
			this.animator = animator;
			animatorSetup = data;
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
		
		private void Transition(int targetStateHash, float duration = 0.1f, float targetAnimOffset = 0f) =>
			animator.CrossFade(targetStateHash, duration, 0, targetAnimOffset);

		public void Update(Vector2 velocity, bool run)
		{
			SetMovement(velocity, run);
		}

		private void SetMovement(Vector2 velocity, bool run)
		{
			SetFloat(xVelFloat, velocity.x, animatorSetup.MovementDampTime);
			SetFloat(yVelFloat, velocity.y, animatorSetup.MovementDampTime);
			SetFloat(runFloat, run ? 1f : 0f, animatorSetup.MovementDampTime);
		}

		public void Melee0() => Transition(melee0);
		public void Dodge(Vector2 dir)
		{
			SetFloat(xDodgeDir, dir.x);
			SetFloat(yDodgeDir, dir.y);
			Transition(dodge, targetAnimOffset: animatorSetup.dodgeOffset);
		}

		public void Melee1() => Transition(melee1, targetAnimOffset: animatorSetup.melee1Offset);
		public void ToMoving() => Transition(movement, animatorSetup.MovingTransDur);
		
		private void SetFloat(int floatHash, float value) => animator.SetFloat(floatHash, value);
		private void SetFloat(int floatHash, float value, float dampTime) => animator.SetFloat(floatHash, value, dampTime,Time.deltaTime);

	}
}