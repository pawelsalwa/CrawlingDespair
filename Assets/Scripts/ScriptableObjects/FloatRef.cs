using UnityEngine;

namespace ScriptableObjects
{
	[CreateAssetMenu(fileName = "FloatVariable", menuName = "ScriptableObjects/FloatRef")]
	public class FloatRef : ScriptableObject
	{
		[SerializeField]
		private float value;

		public float Value
		{
			get => value;
			set => this.value = value;
		}
	}
}