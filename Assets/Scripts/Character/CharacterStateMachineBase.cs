using Character.FSMSetupData;
using UnityEngine;

namespace Character
{
	public abstract class CharacterStateMachineBase
	{
		public bool debugsEnabled = false;
		private CharacterStateBase currentState;

		public string CurrentStateDebug => currentState.TypeName;
		public abstract CharacterStateBase DefaultState { get; }

		protected CharacterStateMachineBase(CharacterInputBase characterInputBase, CharacterBase characterBase, CharacterFSMSetupBase characterFsmSetupBase)
		{ }

		public void PerformTransition(CharacterStateBase targetState)
		{
			if (debugsEnabled)
				Debug.Log($"<color=cyan> <StateMachine> Transition from: <b>{currentState?.TypeName}</b> to: <b>{targetState?.TypeName}</b> </color>");
			currentState?.Exit();
			currentState = targetState;
			currentState.Enter();
		}
		
		public virtual void Update() => currentState.Update();
		public void FixedUpdate() => currentState.FixedUpdate();
	}
}