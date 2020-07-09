// using UnityEngine;
//
// namespace Character.Benedict
// {
// 	public class BenedictPrefabSetupHelper :  CharacterPrefabSetupHelperBase
// 	{
// 		public BenedictPrefabSetupHelper(CharacterBenedict character) : base(character)
// 		{
// 			// Adding components
// 			character.BenedictPrefabSetup.MeshRoot.gameObject
// 				.AddComponent<BipedMovementFXHandler>().Initialize(character, character.PrefabSetup.EnvironmentLayer);
//
// 			// Spawning Prefabs
//
// 			SetupMainDagger(character);
//
// 			SetupExtraDagger(character);
//
// 			SetupFlareGun(character);
//
// 			SetupShield(character);
//
// 			SetupAnchor(character);
//
// 			var headLight = Object.Instantiate(character.BenedictPrefabSetup.Light, character.BenedictPrefabSetup.LightContainer);
// 		}
//
// 		private void SetupExtraDagger(CharacterBenedict character)
// 		{
// 			var extraDagger = Object.Instantiate(character.BenedictPrefabSetup.DaggerTemplate,
// 				character.BenedictPrefabSetup.AdditionalWeaponContainer);
// 			CharactersDeathMeshDissolver.AddMeshToDissolver(extraDagger.transform);
// 		}
//
// 		private void SetupMainDagger(CharacterBenedict character)
// 		{
// 			character.BenedictPrefabSetup.Dagger = Object.Instantiate(character.BenedictPrefabSetup.DaggerTemplate, character.BenedictPrefabSetup.MeleeWeaponContainer);
// 			CharactersDeathMeshDissolver.AddMeshToDissolver(character.BenedictPrefabSetup.Dagger.transform);
// 		}
//
// 		private void SetupFlareGun(CharacterBenedict character)
// 		{
// 			character.BenedictPrefabSetup.FlareGun = Object.Instantiate(character.BenedictPrefabSetup.FlareGunTemplate, character.BenedictPrefabSetup.FirearmContainer);
// 			character.BenedictPrefabSetup.FlareGun.Init(character.CharacterController, character.BenedictRuntimeData.CurrentAmmo);
// 			CharactersDeathMeshDissolver.AddMeshToDissolver(character.BenedictPrefabSetup.FlareGun.transform);
// 		}
//
// 		private void SetupShield(CharacterBenedict character)
// 		{
// 			var newShield = Object.Instantiate(character.BenedictPrefabSetup.ShieldTemplate, character.BenedictPrefabSetup.ShieldContainer, false);
// 			character.BenedictPrefabSetup.Shield = newShield.GetComponent<ParticleSystem>();
// 		}
//
// 		private void SetupAnchor(CharacterBenedict character)
// 		{
// 			var newAnchor = Object.Instantiate(character.BenedictPrefabSetup.AnchorTemplate, character.BenedictPrefabSetup.EquipmentContainer, false);
// 			newAnchor.SetActive(false);
// 			character.BenedictPrefabSetup.Anchor = newAnchor;
// 		}
// 	}
// }