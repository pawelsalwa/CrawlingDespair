using System;

namespace Pawn.Teddy
{
	public class PawnTeddy : Pawn
	{
		public static event Action<PawnTeddy> OnSpawned;
		
		private InputController inputController;

		protected override void Start()
		{
			base.Start();
			inputController = new InputController(Input);
		}

		protected override void Update()
		{
			inputController.Update();
			base.Update();
		}
	}
}