using Input;
using UnityEngine;

namespace Character.Teddy
{
	public class TeddyInputController : CharacterInputControllerBase
	{
		private readonly InputMappingWrapper inputMappingWrapper;
		private TeddyInput teddyInput => CharacterInput as TeddyInput;
		private InputMapping.PlayerActions PlayerActions => inputMappingWrapper.InputMapping.Player;
		
		public TeddyInputController(TeddyInput characterInput, InputMappingWrapper inputMappingWrapper) : base(characterInput)
		{
			this.inputMappingWrapper = inputMappingWrapper;
		}

		public override void Update()
		{
			teddyInput.Movement = PlayerActions.Move.ReadValue<Vector2>();
			teddyInput.Attack = PlayerActions.Fire.triggered;
		}
	}
}