using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pawn
{
	public class PlayerController : Controller
	{
		
		private InputMapping.PlayerActions PlayerActions => InputMappingWrapper.InputMapping.Player;

		public override void UpdateInput(Input input)
		{
			input.Movement = PlayerActions.Move.ReadValue<Vector2>();
			input.Attack = PlayerActions.Fire.triggered;
			input.Dodge = PlayerActions.Dodge.triggered;
			input.Run = PlayerActions.Run.phase == InputActionPhase.Started;
		}
	}
}