using Character.Ai;
using NaughtyAttributes;
using UnityEngine;
using Blackboard = UnityEditor.Experimental.GraphView.Blackboard;

namespace Character
{
	public class AiController : Controller
	{
		[Expandable]
		public AiSetup aiSetup;

		private Blackboard bb;

		public Bt bt;
		// public string stateDebug => bb.currentNodeDebug.GetType().ToString();

		public override void UpdateInput(PlayerInput playerInput) => bt.UpdateInput(playerInput);

		protected override void Start()
		{
			base.Start();
			// bt = ScriptableObject.CreateInstance<Bt>();
		}
	}
}