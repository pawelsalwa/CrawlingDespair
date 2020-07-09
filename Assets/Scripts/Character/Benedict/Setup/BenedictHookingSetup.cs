using System;
using UnityEngine;

namespace Character.Benedict.Setup
{
    [Serializable]
    public class BenedictHookingSetup
    {
        [Tooltip("Enviro layer mask. Specifies objects that hook can attach.")]
        public LayerMask HookRaycastLayerMask;
        [Tooltip("Range of raycast to seek for hook target.")]
        public float HookRange = 9f; //In the future this might be replaced with FloatVariable ScriptableObject.
    }
}