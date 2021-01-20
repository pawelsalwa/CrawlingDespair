using UnityEngine;

namespace Pawn
{
	[RequireComponent(typeof(Pawn))]
	public class Controller : MonoBehaviour
	{

		protected virtual void Start() => GetComponent<Pawn>().Controller = this;

		public virtual void UpdateInput(Input input)
		{
		}
	}
}