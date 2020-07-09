using System;
using Character.FSMSetupData;
using UnityEngine;

namespace Character
{
	/// <summary>
	/// Base class for FSM states. Inherit constructor to setup proper implementations of:
	/// <see cref="CharacterBase"/>
	/// <see cref="CharacterInputBase"/>
	/// <see cref="CharacterStateMachineBase"/>
	/// </summary>
	[Serializable]
	public abstract class CharacterStateBase
	{
		public string TypeName => GetType().Name;
		
		protected readonly CharacterBase characterBase;
		protected readonly CharacterInputBase characterInput;
		protected readonly CharacterStateMachineBase stateMachine;
		protected readonly StateDataBase stateDataBase;

		protected float stateProgress = 0f;
		protected float fixedStateProgress = 0f;

		protected CharacterStateBase(CharacterInputBase characterInput, CharacterBase characterBase, CharacterStateMachineBase stateMachine, StateDataBase stateDataBase)
		{
			this.characterInput = characterInput;
			this.characterBase = characterBase;
			this.stateMachine = stateMachine;
			this.stateDataBase = stateDataBase;
		}

		protected virtual CharacterStateBase DefaultNextState => stateMachine.DefaultState;
		protected virtual float StateDuration => stateDataBase.StateDuration;
		protected float ProgressPercentage => stateProgress / stateDataBase.StateDuration;

		protected bool Active { get; private set; } = false;

		public void Enter()
		{
			stateProgress = fixedStateProgress = 0f;
			Active = true;
			OnEnter();
		}

		public void Update()
		{
			OnUpdate();
			
			if ((stateProgress += Time.deltaTime) >= StateDuration && stateDataBase.HasExitTime)
			{
				OnBeforeTransitionByExitTime();
				RequestTransition(DefaultNextState);
			}
		}

		public void FixedUpdate()
		{
			fixedStateProgress += Time.fixedDeltaTime;
			OnFixedUpdate();
		}

		public void Exit()
		{
			OnExit();
			Active = false;
		}
		
		protected virtual void OnEnter() { }
		protected virtual void OnUpdate() { }
		protected virtual void OnFixedUpdate() { }
		
		/// <summary>
		/// This is called before state is transitioning to next state due to exit time.
		/// Useful if we want to apply logic when state duration comes to an end and state is not exited by any other factor.
		/// Can be used to override <see cref="DefaultNextState"/>.
		/// </summary>
		protected virtual void OnBeforeTransitionByExitTime() { }
		protected virtual void OnExit() { }

		protected void RequestTransition(CharacterStateBase targetState)
		{
			stateMachine.PerformTransition(targetState);
		}
	}
}