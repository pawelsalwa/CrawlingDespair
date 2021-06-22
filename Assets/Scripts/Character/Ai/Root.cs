namespace Character.Ai
{
	public class Root : Selector
	{
		public Root(Blackboard bb) : base(bb)
		{
			Node idle = new Idle(bb);
			Node chase = new Aggro(bb);

			children.Add(idle);
			children.Add(chase);
		}
	}
}