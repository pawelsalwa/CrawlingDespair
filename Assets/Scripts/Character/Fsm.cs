using Character.FSMSetupData;
using Character.Teddy;
using UnityEngine;

namespace Character
{
	public abstract class Fsm
	{
		private readonly Input input;
		private readonly CharacterBase characterBase;
		private readonly CharacterFSMSetupBase characterFsmSetupBase;

		private CharacterStateBase currentState;

		public string CurrentStateDebug => currentState.TypeName;
		public abstract CharacterStateBase DefaultState { get; }

		protected Fsm(CharacterBase characterBase, CharacterFSMSetupBase characterFsmSetupBase)
		{
			this.characterBase = characterBase;
			this.characterFsmSetupBase = characterFsmSetupBase;
			input = characterBase.Input;
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