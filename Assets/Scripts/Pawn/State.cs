using System;
using UnityEngine;

namespace Pawn
{
	public abstract class State
	{
		public string TypeName => GetType().Name;
		
		protected readonly Pawn pawn;
		protected readonly StateSetup stateSetup;
		protected readonly Fsm fsm;
		protected readonly Input input;

		protected float stateProgress = 0f;
		protected float fixedStateProgress = 0f;

		protected State(Fsm fsm, StateSetup stateSetup)
		{
			this.stateSetup = stateSetup;
			this.fsm = fsm;
			pawn = fsm.Pawn;
			input = pawn.Input;
		}

		protected virtual State DefaultNextState => fsm.DefaultState;
		protected virtual float StateDuration => stateSetup.ExitTime;
		protected float ProgressPercentage => stateProgress / stateSetup.ExitTime;

		protected abstract Action AnimCall { get; }

		protected bool Active { get; private set; } = false;

		public void Enter()
		{
			stateProgress = fixedStateProgress = 0f;
			Active = true;
			if (AnimCall == null) Debug.Log($"<color=white> {pawn.gameObject.name}: no anim set for state: {GetType()}</color>", pawn.gameObject);
			else AnimCall.Invoke();
			OnEnter();
		}

		public void Update()
		{
			OnUpdate();
			
			if ((stateProgress += Time.deltaTime) >= StateDuration && stateSetup.HasExitTime)
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

		protected void RequestTransition(State targetState)
		{
			fsm.PerformTransition(targetState);
		}
	}
}