namespace Pawn.Teddy
{
	public class PawnTeddy : Pawn
	{
		private TeddyInputController teddyInputController;

		protected override void Start()
		{
			base.Start();
			teddyInputController = new TeddyInputController(Input);
		}

		protected override void Update()
		{
			teddyInputController.Update();
			base.Update();
		}
	}
}