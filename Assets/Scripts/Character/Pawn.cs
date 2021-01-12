using GameCore;
using UnityEngine;

namespace Character
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(Animator))]
	public abstract class Pawn : MonoBehaviour
	{
		public CharacterMovementBase Movement;
		public Fsm Fsm;
		[HideInInspector] public Input Input;
		[Inspectable] public CharacterSetup setup;
		public CharacterAnimator Animator;
		public Refs Refs;
		
		private Animator animatorComponent;

		protected virtual void Start()
		{
			animatorComponent = GetComponent<Animator>();
			Movement = new CharacterMovementBase(GetComponent<CharacterController>(), setup.MovementSetup);
			Animator = new CharacterAnimator(animatorComponent, setup.AnimatorSetup);
			Fsm = new Fsm(this, setup.fsmSetup);
		}

		protected virtual void Update()
		{
			Fsm?.Update();
			Movement.Update();
			Animator.Update(Movement.InternalCharacterVelocity, Input.Run);
		}
		
		protected virtual void FixedUpdate()
		{
			Fsm?.FixedUpdate();
		}

		private void OnValidate()
		{
			if (Refs.overrideInput)
			{
				Input.Attack = Refs.DebugInput.Attack;
				Input.Dodge = Refs.DebugInput.Dodge;
				Input.Run = Refs.DebugInput.Run;
				Input.Movement = Refs.DebugInput.Movement;
			} 
		}

		private void OnAnimatorMove()
		{
			Movement.OnAnimatorMove(animatorComponent.deltaPosition);
		}
	}
}