
using UnityEngine;

namespace Character.Teddy
{
	public class CharacterTeddy : CharacterBase
	{
		private TeddySetup teddySetup;
		private TeddyInputController teddyInputController;

		public TeddyPrefabRefs Refs;
		public TeddyAnimator TeddyAnimator;

		protected override void Start()
		{
			base.Start();
			TeddyAnimator = new TeddyAnimator(Animator, teddySetup.TeddyAnimatorSetup);
			Fsm = new TeddyFsm(this, teddySetup.teddyFsmSetup);

			teddyInputController = new TeddyInputController(Input);
		}

		protected override void Update()
		{
			teddyInputController.Update();
			base.Update();
			TeddyAnimator.Update(Movement.InternalCharacterVelocity, Input.Run);
		}

		private void OnValidate()
		{
			ValidateSetupType();

			if (Refs.overrideInput)
			{
				Input.Attack = Refs.DebugInput.Attack;
				Input.Dodge = Refs.DebugInput.Dodge;
				Input.Run = Refs.DebugInput.Run;
				Input.Movement = Refs.DebugInput.Movement;
			} 
		}

		private void ValidateSetupType()
		{
			if (Setup == null) return;
			teddySetup = (TeddySetup) Setup;
			if (teddySetup == null)
				Debug.LogError($"<color=red> Assigned setup of wrong type. </color>");
		}
	}
}