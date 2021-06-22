using UnityEngine;

namespace Character.Ai.Editor
{
	public class Block
	{
		public Rect rect;
		public Node node;
		
		public Vector2 offset = Vector2.zero;
		private string title;

		public GUIStyle style = new GUIStyle();

		private static Texture2D greenTex;
		private static Texture2D grayTex;
		private static Texture2D selectedTex;

		public Block(Node node)
		{
			this.node = node;
			title = node.GetType().ToString();
		}

		public void Draw()
		{
			var offRect = rect;
			offRect.center += offset;
			GUI.Box(offRect, title, style);
			var btnRect = new Rect(offRect.x, offRect.y + 20, offRect.width, 20);
			if (GUI.Button(btnRect, "Set stage"))
			{
			}
		}

	}
}