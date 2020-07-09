using Character;
using Character.Teddy;
using UnityEngine;

public class CharacterTeddy : CharacterBase
{

    [SerializeField] private TeddyDataSetup teddyDataSetup = null;
    [SerializeField] private TeddyPrefabSetup teddyPrefabSetup = null;
    
    private TeddyInput teddyInput;
    private TeddyStateMachine teddyStateMachine;
    private TeddyAnimator teddyAnimator;
    private TeddyAnimatorUpdateData teddyAnimatorUpdateData;
    private TeddyInputController teddyInputController;
    private TeddyMovement teddyMovement;

    public override CharacterMovementBase CharacterMovementBase => teddyMovement;
    
    protected override CharacterStateMachineBase CharacterStateMachineBase => teddyStateMachine;
    protected override CharacterInputBase CharacterInputBase => teddyInput;
    protected override CharacterDataSetupBase CharacterDataSetupBase => teddyDataSetup;
    protected override CharacterPrefabSetupBase CharacterPrefabSetupBase => teddyPrefabSetup;
    protected override CharacterAnimatorBase CharacterAnimatorBase => teddyAnimator;
    protected override AnimatorUpdateDataBase AnimatorUpdateDataBase => teddyAnimatorUpdateData;
    protected override CharacterInputControllerBase CharacterInputControllerBase => teddyInputController;

    protected override void Start()
    {
        base.Start();
        
        teddyInput = new TeddyInput();
        teddyStateMachine = new TeddyStateMachine(teddyInput, this, teddyDataSetup.teddyFsmSetup);
        
        teddyInputController = new TeddyInputController(teddyInput, teddyPrefabSetup.InputMappingWrapper);
        
        teddyAnimator = new TeddyAnimator(teddyPrefabSetup.Animator);
        teddyAnimatorUpdateData = new TeddyAnimatorUpdateData();


        teddyMovement = new TeddyMovement(CharacterController, teddyDataSetup.MovementSetup);
    }
}
