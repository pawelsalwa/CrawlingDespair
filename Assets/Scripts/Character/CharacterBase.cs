using Character.Teddy;
using UnityEngine;

namespace Character
{
	public abstract class CharacterBase : MonoBehaviour, IDamagable
	{

		public CharacterHealth CharacterHealth;
		[HideInInspector] public CharacterController CharacterController;
		
		public abstract CharacterStateMachineBase CharacterStateMachineBase { get; }
		public abstract CharacterInputBase CharacterInputBase { get; }
		public abstract CharacterDataSetupBase CharacterDataSetupBase { get; }
		public abstract AnimatorUpdateDataBase AnimatorUpdateDataBase { get; }
		public abstract CharacterInputControllerBase CharacterInputControllerBase { get; }

		public bool IsDestroyed => !CharacterHealth.IsHpAboveZero;

		public void TakeDamage(DamageData damageData) => CharacterHealth.TakeDamage(damageData);

		protected virtual void Start()
		{
			CharacterController = GetComponent<CharacterController>();
			CharacterHealth = new CharacterHealth(CharacterDataSetupBase.TeddyMaxHealth, CharacterDataSetupBase.TeddyHealth);
		}

		protected virtual void Update()
		{
			CharacterInputControllerBase.Update();
			CharacterStateMachineBase.Update();
		}
		
		protected virtual void FixedUpdate()
		{
			CharacterStateMachineBase.FixedUpdate();
		}
	}
}