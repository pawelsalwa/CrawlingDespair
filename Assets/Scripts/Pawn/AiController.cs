using GameCore;
using Pawn.Bt;

namespace Pawn
{
	public class AiController : Controller
	{
		[Inspectable]
		public AiSetup aiSetup;

		private Bt.Bt bt;

		public override void UpdateInput(Input input) => bt.Update(input);

		protected override void Start()
		{
			base.Start();
			bt = new Bt.Bt(aiSetup, transform);
		}
	}
}