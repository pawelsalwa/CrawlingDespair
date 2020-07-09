using UnityEngine;

namespace Character.Benedict
{
	public class BenedictInput : CharacterInputBase
	{
		public Vector2 Movement;
		public Vector2 RightAnalogDirection;
		public bool Aiming;
		public bool Sprint;
		public bool Attack;
		public bool Jump;
		public bool JumpDown;
		public bool ThrowHook;
		public bool ToggleCrouch;
		public bool Block;
		public bool Dodge;
		public bool Interact;
		public bool ReloadAmmo;
		public bool UseEquipmentItem;
		public bool NextEquipmentItem;
		public bool PreviousEquipmentItem;
		public bool SetAnchor;
		public bool InGameMenu;

		// Movement.magnitude < 0.1f && AimDirection.magnitude < 0.1f && Aiming && Sprint && Attack &&
		//                                 ToggleCrouch && Block && Dodge && Interact && ReloadAmmo && UseEquipmentItem && NextEquipmentItem && PreviousEquipmentItem;
	}
}