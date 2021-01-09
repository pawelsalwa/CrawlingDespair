using UnityEngine;

namespace Character.Teddy
{
	public class CharacterTeddy : CharacterBase
	{
		[SerializeField] private TeddyDataSetup teddyDataSetup = null;

		private TeddyInput teddyInput;
		private TeddyStateMachine teddyStateMachine;
		private TeddyAnimatorUpdateData teddyAnimatorUpdateData;
		private TeddyInputController teddyInputController;
		public CharacterMovementBase Movement;

		public TeddyPrefabRefs Refs;
		public TeddyAnimator TeddyAnimator;

		
		public override CharacterStateMachineBase CharacterStateMachineBase => teddyStateMachine;
		public override CharacterInputBase CharacterInputBase => teddyInput;
		public override CharacterDataSetupBase CharacterDataSetupBase => teddyDataSetup;
		public override AnimatorUpdateDataBase AnimatorUpdateDataBase => teddyAnimatorUpdateData;
		public override CharacterInputControllerBase CharacterInputControllerBase => teddyInputController;

		protected override void Start()
		{
			base.Start();

			Movement = new CharacterMovementBase(CharacterController, teddyDataSetup.MovementSetup);
			TeddyAnimator = new TeddyAnimator(Refs.animator, teddyDataSetup.TeddyAnimatorSetup);
			teddyInput = new TeddyInput();
			teddyStateMachine = new TeddyStateMachine(teddyInput, this, teddyDataSetup.teddyFsmSetup);

			teddyInputController = new TeddyInputController(teddyInput);

			// teddyMovement = new TeddyMovement(CharacterController, teddyDataSetup.MovementSetup);
		}

		protected override void Update()
		{
			base.Update();
			teddyAnimatorUpdateData = new TeddyAnimatorUpdateData {velocity = Movement.InternalCharacterVelocity, run = teddyInput.Run};
			TeddyAnimator.Update(teddyAnimatorUpdateData);
			Movement.Update();
		}

		public void OnAnimatorMove()
		{
			Movement.OnAnimatorMove(Refs.animator.deltaPosition);
		}
	}
}