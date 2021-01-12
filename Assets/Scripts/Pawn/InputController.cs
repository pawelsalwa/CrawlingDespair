using Input;
using Pawn.Teddy;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pawn
{
	public class InputController
	{
		private readonly Input input;

		private InputMapping.PlayerActions PlayerActions => InputMappingWrapper.InputMapping.Player;
		
		public InputController(Input input)
		{
			this.input = input;
		}

		public void Update()
		{
			input.Movement = PlayerActions.Move.ReadValue<Vector2>();
			input.Attack = PlayerActions.Fire.triggered;
			input.Dodge = PlayerActions.Dodge.triggered;
			input.Run = PlayerActions.Run.phase == InputActionPhase.Started;
		}
	}
}