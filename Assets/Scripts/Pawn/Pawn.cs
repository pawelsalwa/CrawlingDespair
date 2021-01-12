using GameCore;
using UnityEngine;

namespace Pawn
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(Animator))]
	public abstract class Pawn : MonoBehaviour
	{
		public PawnMovementBase Movement;
		public Fsm Fsm;
		[HideInInspector] public Input Input;
		[Inspectable, SerializeField] private PawnSetup setup;
		public PawnAnimator Animator;
		public Refs Refs;
		
		private Animator animatorComponent;

		protected virtual void Start()
		{
			animatorComponent = GetComponent<Animator>();
			Movement = new PawnMovementBase(GetComponent<CharacterController>(), setup.Movement);
			Animator = new PawnAnimator(animatorComponent, setup.Animator);
			Fsm = new Fsm(this, setup.Fsm);
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