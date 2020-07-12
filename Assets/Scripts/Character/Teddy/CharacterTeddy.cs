using Character;
using Character.Teddy;
using UnityEngine;

public class CharacterTeddy : CharacterBase
{
	[SerializeField] private TeddyDataSetup teddyDataSetup = null;
	[SerializeField] private TeddyPrefabSetup teddyPrefabSetup = null;

	private TeddyInput teddyInput;
	private TeddyStateMachine teddyStateMachine;
	public TeddyAnimator TeddyAnimator;
	private TeddyAnimatorUpdateData teddyAnimatorUpdateData;
	private TeddyInputController teddyInputController;
	private TeddyMovement teddyMovement;

	public override CharacterMovementBase CharacterMovementBase => teddyMovement;

	protected override CharacterStateMachineBase CharacterStateMachineBase => teddyStateMachine;
	protected override CharacterInputBase CharacterInputBase => teddyInput;
	protected override CharacterDataSetupBase CharacterDataSetupBase => teddyDataSetup;
	protected override CharacterPrefabSetupBase CharacterPrefabSetupBase => teddyPrefabSetup;
	protected override CharacterAnimatorBase CharacterAnimatorBase => TeddyAnimator;
	protected override AnimatorUpdateDataBase AnimatorUpdateDataBase => teddyAnimatorUpdateData;
	protected override CharacterInputControllerBase CharacterInputControllerBase => teddyInputController;

	protected override void Start()
	{
		base.Start();

		TeddyAnimator = new TeddyAnimator(teddyPrefabSetup.Animator, teddyDataSetup.TeddyAnimatorSetup);
		teddyInput = new TeddyInput();
		teddyStateMachine = new TeddyStateMachine(teddyInput, this, teddyDataSetup.teddyFsmSetup);

		teddyInputController = new TeddyInputController(teddyInput, teddyPrefabSetup.InputMappingWrapper);

		teddyMovement = new TeddyMovement(CharacterController, teddyDataSetup.MovementSetup);
	}

	protected override void Update()
	{
		teddyAnimatorUpdateData = new TeddyAnimatorUpdateData {velocity = CharacterMovementBase.InternalCharacterVelocity, run = teddyInput.Run};
		base.Update();
	}
}