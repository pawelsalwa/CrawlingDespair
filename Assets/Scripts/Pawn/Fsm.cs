using Pawn.Setup;
using Pawn.States;
using UnityEngine;

namespace Pawn
{
	public class Fsm
	{
		public readonly Pawn Pawn;

		private State currentState;

		public Fsm(Pawn pawn, FsmSetup setup)
		{
			Pawn = pawn;

			Move = new Move(this, setup.moving);
			Attack0 = new Attack0(this, setup.attack0);
			Attack1 = new Attack1(this, setup.attack1);
			Dodge = new Dodge(this, setup.dodge);

			PerformTransition(Move);
		}

		public State DefaultState => Move;
		
		public State Attack0; 
		public State Attack1; 
		public State Dodge; 
		public State Move;

		public void PerformTransition(State targetState)
		{
			if (Pawn.Refs.FsmDebugs) Debug.Log($"<color=cyan> <StateMachine> Transition from: <b>{currentState?.TypeName}</b> to: <b>{targetState?.TypeName}</b> </color>");
			currentState?.Exit();
			currentState = targetState;
			currentState.Enter();
		}
		
		public virtual void Update() => currentState.Update();
		public void FixedUpdate() => currentState.FixedUpdate();
	}
}