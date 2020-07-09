// using System.Collections.Generic;
// using Combat;
// using GameCore;
// using RootMotion.FinalIK;
// using Scriptables.Equipment;
// using Scriptables.Events;
// using Scriptables.Pools;
// using UnityEngine;
// using static Tools.TooltipsStrings;
//
// namespace Character.Benedict
// {
// 	[HelpURL(BenedictPrefabSetupTooltipsStrings.HelpUrl)]
// 	public class BenedictPrefabSetup : CharacterPrefabSetupBase
// 	{
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.Equipment)]
// 		public ConsumableEquipment consumableEquipment;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.StoryEquipment)]
// 		public StoryEquipment StoryEquipment;
//
// 		[Header("Additional Transforms:")]
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.LeftHand)]
// 		public Transform LeftHand;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.RightHand)]
// 		public Transform RightHand;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.LightContainer)]
// 		public Transform LightContainer;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.ShieldContainer)]
// 		public Transform ShieldContainer;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.FirearmContainer)]
// 		public Transform FirearmContainer;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.MeleeWeaponContainer)]
// 		public Transform MeleeWeaponContainer;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.AdditionalWeaponContainer)]
// 		public Transform AdditionalWeaponContainer;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.EquipmentContainer)]
// 		public Transform EquipmentContainer;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.AnchorPlacementTestOrigin)]
// 		public Transform AnchorPlacementTestOrigin;
//
// 		[Header("Additional Sounds:")]
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.ShieldHitSounds)]
// 		public List<SoundPoolDetails> ShieldHitSounds;
//
// 		[Header("Additional Particles:")]
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.Slash1)]
// 		public ParticleSystem Slash1;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.Slash2)]
// 		public ParticleSystem Slash2;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.Thrust)]
// 		public ParticleSystem Thrust;
//
// 		[Header("Additional Components:")]
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.HookLineRenderer)]
// 		public LineRenderer HookLineRenderer;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.AimIK)]
// 		public AimIK AimIk;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.FullBodyBipedIk)]
// 		public FullBodyBipedIK FullBodyBipedIk;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.GrounderFBBIK)]
// 		public GrounderFBBIK GrounderFBBIK;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.CharacterIKManager)]
// 		public CharacterIKManager CharacterIKManager;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.BenedictInteractionDetector)]
// 		public BenedictInteractionDetector BenedictInteractionDetector;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.MeleeDamageArea)]
// 		public MeleeDamageArea MeleeDamageArea;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.HookTrap)]
// 		public GameObject HookTrap;
// 		
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.ClimbableLedgeDetector)]
// 		public ClimbableLedgeDetector climbableLedgeDetector;
// 		
// 		[Header("Templates")]
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.Light)]
// 		public GameObject Light;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.DaggerTemplate)]
// 		public Dagger DaggerTemplate;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.FlareGunTemplate)]
// 		public FlareGun FlareGunTemplate;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.ShieldTemplate)]
// 		public GameObject ShieldTemplate;
//
// 		[Tooltip(BenedictPrefabSetupTooltipsStrings.AnchorTemplate)]
// 		public GameObject AnchorTemplate;
//
// 		[Header("Game specific scriptable events")] // testowo
// 		public CameraShakeEvent CameraShakeEvent;
// 		public CameraSwitchEvent CameraSwitchEvent;
// 		public InteractionPanelEventHandler InteractionPanelEventHandler;
// 		public CompanionPromptEventHandler CompanionPromptEventHandler;
// 		
// 		[Header("Instantiated Items")]
// 		[HideInInspector] public Dagger Dagger;
// 		[HideInInspector] public FlareGun FlareGun;
// 		[HideInInspector] public ParticleSystem Shield;
// 		[HideInInspector] public GameObject Anchor;
// 	}
// }