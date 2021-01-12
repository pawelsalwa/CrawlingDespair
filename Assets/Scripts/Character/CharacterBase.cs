using GameCore;
using UnityEngine;

namespace Character
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(Animator))]
	public abstract class CharacterBase : MonoBehaviour
	{
		public CharacterMovementBase Movement;
		public Fsm Fsm;
		[HideInInspector] public Input Input;
		[Inspectable] public CharacterSetup Setup;
		[HideInInspector]public Animator Animator;

		protected virtual void Start()
		{
			Animator = GetComponent<Animator>();
			Movement = new CharacterMovementBase(GetComponent<CharacterController>(), Setup.MovementSetup);
		}

		protected virtual void Update()
		{
			Fsm?.Update();
			Movement.Update();
		}
		
		protected virtual void FixedUpdate()
		{
			Fsm.FixedUpdate();
		}

		private void OnAnimatorMove()
		{
			Movement.OnAnimatorMove(Animator.deltaPosition);
		}
	}
}