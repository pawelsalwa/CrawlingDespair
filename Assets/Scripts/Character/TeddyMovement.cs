using Character.SetupData;
using UnityEngine;

namespace Character
{
	public class TeddyMovement : CharacterMovementBase
	{

		public TeddyMovement(CharacterController characterController, MovementSetupBase movementSetupBase) : base(characterController, movementSetupBase)
		{
		}
		
		public override void StopWalking()
		{
			
		}

	}
}