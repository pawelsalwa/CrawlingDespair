using UnityEngine;

namespace Character.Benedict
{
	public class BenedictInputController : CharacterInputControllerBase
	{
		// private InputMapping.BenedictControllActions benedictActions;
		//
		// private BenedictInput BenedictInput => CharacterInput as BenedictInput;
		//
		// private bool hookReseted = true;
		//
		// public BenedictInputController(InputMappingWrapper inputMappingWrapper, BenedictInput characterInput) :
		// 	base(characterInput)
		// {
		// 	this.benedictActions = inputMappingWrapper.InputMapping.BenedictControll;
		// }
		//
		public BenedictInputController(CharacterInputBase characterInput) : base(characterInput)
		{
		}
		public override void Update()
		{
		} //gathers input each frame for further processing}
		// {
		// 	BenedictInput.Movement = benedictActions.xMove.ReadValue<Vector2>();
		// 	BenedictInput.RightAnalogDirection = benedictActions.AimDirection.ReadValue<Vector2>();
		//
		// 	BenedictInput.Sprint = benedictActions.Sprint.phase == InputActionPhase.Started;
		// 	BenedictInput.Aiming = benedictActions.Aiming.phase == InputActionPhase.Started;
		//
		// 	BenedictInput.Jump = benedictActions.Jump.triggered;
		// 	BenedictInput.JumpDown = benedictActions.Jump.phase == InputActionPhase.Started;
		// 	BenedictInput.Attack = benedictActions.Attack.phase == InputActionPhase.Started;
		// 	BenedictInput.Dodge = benedictActions.Dodge.triggered;
		// 	BenedictInput.Block = benedictActions.Block.triggered;
		// 	BenedictInput.Interact = benedictActions.Interact.triggered;
		// 	BenedictInput.ReloadAmmo = benedictActions.ReloadAmmo.triggered;
		// 	BenedictInput.ToggleCrouch = benedictActions.ToggleCrouch.triggered;
		// 	BenedictInput.NextEquipmentItem = benedictActions.NextEquipmentItem.triggered;
		// 	BenedictInput.PreviousEquipmentItem = benedictActions.PreviousEquipmentItem.triggered;
		// 	BenedictInput.UseEquipmentItem = benedictActions.UseEquipmentItem.triggered;
		// 	BenedictInput.SetAnchor = benedictActions.SetAnchor.triggered;
		// 	BenedictInput.InGameMenu = benedictActions.InGameMenu.triggered;
		// 	
		// 	HandleHookInput();
		// }
		//
		// private void HandleHookInput()// TODO czy mozna wyklikac reset z edytora? 
		// {
		// 	if (BenedictInput.RightAnalogDirection.magnitude > 0.9f && hookReseted)
		// 	{
		// 		BenedictInput.ThrowHook = true;
		// 		hookReseted = false;
		// 	}
		// 	else
		// 	{
		// 		BenedictInput.ThrowHook = false;
		// 	}
		//
		// 	hookReseted = hookReseted || BenedictInput.RightAnalogDirection.magnitude < 0.9f;
		// }
	}
}