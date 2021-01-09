using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character.Teddy
{
	public class TeddyInputController : CharacterInputControllerBase
	{
		// private readonly InputMappingWrapper inputMappingWrapper;
		private TeddyInput teddyInput => CharacterInput as TeddyInput;
		private InputMapping.PlayerActions PlayerActions => InputMappingWrapper.InputMapping.Player;
		
		public TeddyInputController(TeddyInput characterInput, InputMappingWrapper inputMappingWrapper) : base(characterInput)
		{
			// this.inputMappingWrapper = inputMappingWrapper;
		}

		public override void Update()
		{
			teddyInput.Movement = PlayerActions.Move.ReadValue<Vector2>();
			teddyInput.Attack = PlayerActions.Fire.triggered;
			teddyInput.Run = PlayerActions.Run.phase == InputActionPhase.Started;
		}
	}
}