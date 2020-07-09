namespace Character
{
	
	/// <summary>
	/// Base class for storage of current frame input 
	/// </summary>
	public abstract class CharacterInputBase
	{
		public virtual bool IsAnyInputActive => false;
	}
}