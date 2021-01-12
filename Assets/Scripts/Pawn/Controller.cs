using UnityEngine;

namespace Pawn
{
	[RequireComponent(typeof(Pawn))]
	public class Controller : MonoBehaviour
	{

		private void Start() => GetComponent<Pawn>().Controller = this;

		public virtual void UpdateInput(Input input)
		{
		}
	}
}