using GameCore;
using UnityEngine;

namespace Pawn
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(Animator))]
	public class Pawn : MonoBehaviour
	{
		public Movement Movement;
		public Fsm Fsm;
		[HideInInspector] public Input Input;
		[Inspectable, SerializeField] private PawnSetup setup;
		public PawnAnimator Animator;
		public Refs Refs;
		
		private Animator animatorComponent;
		public Controller Controller { private get; set; }

		private void Start()
		{
			animatorComponent = GetComponent<Animator>();
			Movement = new Movement(GetComponent<CharacterController>(), setup.Movement);
			Animator = new PawnAnimator(animatorComponent, setup.Animator);
			Fsm = new Fsm(this, setup.Fsm);
		}

		private void Update()
		{
			if (Controller && !Refs.overrideInput) Controller.UpdateInput(Input);
			Fsm?.Update();
			Animator.Update(Movement.InternalCharacterVelocity, Input.Run);
		}
		
		private void FixedUpdate()
		{
			Fsm?.FixedUpdate();
			Movement.FixedUpdate();
		}

		private void OnValidate() => DebugOverrideInput();

		private void DebugOverrideInput()
		{
			if (!Refs.overrideInput) return;
			Input.Attack = Refs.DebugInput.Attack;
			Input.Dodge = Refs.DebugInput.Dodge;
			Input.Run = Refs.DebugInput.Run;
			Input.Movement = Refs.DebugInput.Movement;
		}

		private void OnAnimatorMove() => Movement.OnAnimatorMove(animatorComponent.deltaPosition);
	}
}