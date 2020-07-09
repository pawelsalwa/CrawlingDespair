namespace Character
{
	/// <summary>
	/// This saves current input for further processing in FSM.
	/// For playable character this is connected with UnityInputSystem.
	/// For NPC this is the class to implement AI.
	/// </summary>
	public abstract class CharacterInputControllerBase
	{
		protected CharacterInputBase CharacterInput { get; }

		protected CharacterInputControllerBase(CharacterInputBase characterInput)
		{
			CharacterInput = characterInput;
		}

		public abstract void Update();
	}
}