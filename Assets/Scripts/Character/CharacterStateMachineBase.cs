using Character.FSMSetupData;
using Character.Teddy;
using UnityEngine;

namespace Character
{
	public abstract class CharacterStateMachineBase
	{
		private readonly CharacterInputBase characterInputBase;
		private readonly CharacterBase characterBase;
		private readonly CharacterFSMSetupBase characterFsmSetupBase;
		public bool debugsEnabled = false;
		private CharacterStateBase currentState;

		public string CurrentStateDebug => currentState.TypeName;
		public abstract CharacterStateBase DefaultState { get; }

		protected CharacterStateMachineBase(CharacterInputBase characterInputBase, CharacterBase characterBase, CharacterFSMSetupBase characterFsmSetupBase)
		{
			this.characterInputBase = characterInputBase;
			this.characterBase = characterBase;
			this.characterFsmSetupBase = characterFsmSetupBase;
		}

		public void PerformTransition(CharacterStateBase targetState)
		{
			if (characterBase is CharacterTeddy teddy && teddy.Refs.StateMachineDebugs)
				Debug.Log($"<color=cyan> <StateMachine> Transition from: <b>{currentState?.TypeName}</b> to: <b>{targetState?.TypeName}</b> </color>");
			currentState?.Exit();
			currentState = targetState;
			currentState.Enter();
		}
		
		public virtual void Update() => currentState.Update();
		public void FixedUpdate() => currentState.FixedUpdate();
	}
}