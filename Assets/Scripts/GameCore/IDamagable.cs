namespace Pawn
{
	public interface IDamagable
	{
		bool IsDestroyed { get; }
		void TakeDamage(DamageData damageData);
	}
}