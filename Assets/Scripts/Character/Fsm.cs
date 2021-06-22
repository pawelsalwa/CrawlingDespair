using Character.Setup;
using Character.States;
using UnityEngine;

namespace Character
{
	public class Fsm
	{
		public readonly Character Character;

		private State currentState;

		public Fsm(Character character, FsmSetup setup)
		{
			Character = character;

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
			if (Character.Refs.FsmDebugs) Debug.Log($"<color=cyan> <StateMachine> Transition from: <b>{currentState?.TypeName}</b> to: <b>{targetState?.TypeName}</b> </color>");
			currentState?.Exit();
			currentState = targetState;
			currentState.Enter();
		}
		
		public void Update() => currentState.Update();
		public void FixedUpdate() => currentState.FixedUpdate();
	}
}