using UnityEngine;

namespace Tools
{
	public class FpsPrinter : MonoBehaviour
	{
		public Color fontColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
		public int x = 20, y = 60;

		float deltaTime = 0.0f;

		void LateUpdate()
		{
			deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		}

		void OnGUI()
		{
			int w = Screen.width, h = Screen.height;

			GUIStyle style = new GUIStyle();

			Rect rect = new Rect(x, y, w, h * 2 / 100);
			style.alignment = TextAnchor.UpperLeft;
			style.fontSize = h * 4 / 100;
			style.normal.textColor = fontColor;
			float msec = deltaTime * 1000.0f;
			float fps = 1.0f / Time.deltaTime;
			string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
			GUI.Label(rect, text, style);
		}
	}
}