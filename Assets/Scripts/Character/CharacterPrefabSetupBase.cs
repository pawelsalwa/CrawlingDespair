using Dungeon.Data;
using UnityEngine;

namespace Character
{
	public abstract class CharacterPrefabSetupBase : MonoBehaviour
	{
		public Animator Animator;
		public bool StateMachineDebugs = false;
	}
}