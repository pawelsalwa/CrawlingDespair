using System;
using Character.SetupData;

namespace Character
{
	/// <summary>
	/// This class references scriptable object that contains integer value of characters current health.
	/// It also manages falldown damage on ground contact.
	/// </summary>
	public class CharacterHealth
	{
		// public event Action<DamageData> OnDamageTaken;
		// public event Action<DamageData> OnDamageBlocked;
		public event Action OnDeath;

		// private readonly CharacterHealthSetup characterHealthSetup;
		private readonly IntRef characterRuntimeHealth;
		private readonly IntRef characterMaxHealth;

		public bool IsHpAboveZero => characterRuntimeHealth.Value > 0;
		// public int CurrentHP => characterRuntimeHealth.Value;
		// public int MaxHP => characterHealthSetup.MaxHP;

		// public bool Invulnerable { private get; set; }

		public CharacterHealth(IntRef characterMaxHealth, IntRef characterRuntimeHealth)
		{
			// this.characterHealthSetup = characterHealthSetup;
			this.characterRuntimeHealth = characterRuntimeHealth;
			this.characterMaxHealth = characterMaxHealth;
		}

		public void TakeDamage(DamageData damageData)
		{
			if (!IsHpAboveZero)
				return;

			characterRuntimeHealth.Value -= damageData.Value;
			// OnDamageTaken?.Invoke(damageData);
			if (!IsHpAboveZero)
				OnDeath?.Invoke();
		}
	}
}