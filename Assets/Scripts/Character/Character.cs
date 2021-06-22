using Character.Setup;
using Common.Utility;
using NaughtyAttributes;
using UnityEngine;

namespace Character
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(Animator))]
	public class Character : MonoBehaviour
	{
		public Movement Movement;
		public Fsm Fsm;
		[HideInInspector] public PlayerInput playerInput;
		[Expandable, SerializeField] private PawnSetup setup;
		public PawnAnimator Animator;
		public Refs Refs;

		public Optional<int> xdd;
		
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
			if (Controller && !Refs.overrideInput) Controller.UpdateInput(playerInput);
			Fsm?.Update();
			Animator.Update(Movement.InternalCharacterVelocity, playerInput.Run);
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
			playerInput.Attack = Refs.debugPlayerInput.Attack;
			playerInput.Dodge = Refs.debugPlayerInput.Dodge;
			playerInput.Run = Refs.debugPlayerInput.Run;
			playerInput.Movement = Refs.debugPlayerInput.Movement;
		}

		private void OnAnimatorMove() => Movement.OnAnimatorMove(animatorComponent.deltaPosition);
	}
}