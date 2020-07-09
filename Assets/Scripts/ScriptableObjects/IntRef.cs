using UnityEngine;

[CreateAssetMenu(fileName = "IntegerVariable", menuName = "ScriptableObjects/IntRef")]
public class IntRef : ScriptableObject
{
	[SerializeField]
	private int value;

	public int Value
	{
		get => value;
		set => this.value = value;
	}
}