using Character.Teddy;
using UnityEngine;

namespace Character
{
	public abstract class CharacterBase : MonoBehaviour, IDamagable
	{

		public CharacterHealth CharacterHealth;
		[HideInInspector] public CharacterController CharacterController;

		public abstract CharacterMovementBase CharacterMovementBase { get; }
		protected abstract CharacterStateMachineBase CharacterStateMachineBase { get; }
		protected abstract CharacterInputBase CharacterInputBase { get; }
		protected abstract CharacterDataSetupBase CharacterDataSetupBase { get; }
		protected abstract CharacterPrefabSetupBase CharacterPrefabSetupBase { get; }
		protected abstract CharacterAnimatorBase CharacterAnimatorBase { get; }
		protected abstract AnimatorUpdateDataBase AnimatorUpdateDataBase { get; }
		protected abstract CharacterInputControllerBase CharacterInputControllerBase { get; }

		public bool IsDestroyed => !CharacterHealth.IsHpAboveZero;

		public void TakeDamage(DamageData damageData) => CharacterHealth.TakeDamage(damageData);

		protected virtual void Start()
		{
			CharacterController = GetComponent<CharacterController>();
			CharacterHealth = new CharacterHealth(CharacterDataSetupBase.TeddyMaxHealth, CharacterDataSetupBase.TeddyHealth);
		}

		protected virtual void Update()
		{
			CharacterStateMachineBase.debugsEnabled = CharacterPrefabSetupBase.StateMachineDebugs;

			CharacterInputControllerBase.Update();
			CharacterStateMachineBase.Update();
			CharacterAnimatorBase.Update(AnimatorUpdateDataBase);
			CharacterMovementBase.Update();
		}
		
		protected virtual void FixedUpdate()
		{
			CharacterStateMachineBase.FixedUpdate();
		}
	}
}