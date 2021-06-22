using System.Collections.Generic;
using System.Linq;
using Pawn;
using UnityEditor;
using UnityEngine;

namespace Character.Ai.Editor
{
	public class BtWindow : EditorWindow
	{

		private Vector2 offset;

		private List<List<Node>> nodes = new List<List<Node>>();
		private List<Block> blocks = new List<Block>();
		
		public bool EnableDebugs = true;
		private Node root;
		private float horiSpacing = 50;
		private float vertSpacing = 50;
		private Vector2 boxSize = new Vector2(100, 50);

		[MenuItem("Salwa/Behavior Tree Window")]
		private static void CreateWindow()
		{
			var window = GetWindow<BtWindow>();
			window.titleContent = new GUIContent("Behavior Tree");
		}

		public void OnEnable()
		{
			OnSelectionChanged();
			Selection.selectionChanged -= OnSelectionChanged;
			Selection.selectionChanged += OnSelectionChanged;
		}

		private void OnDisable() => Selection.selectionChanged -= OnSelectionChanged;

		private void OnSelectionChanged()
		{
			AiController aiController = null;
			if (Selection.activeGameObject != null)
				aiController =  Selection.activeGameObject.GetComponent<AiController>();
			Node root = aiController?.bt?.root;
			if (root == null && Selection.activeObject is Bt bt) root = bt.root;
			if (root == null) return;
			Init(root);
		}

		private void Init(Node rootNode)
		{
			root = rootNode;
			PopulateMatrix();
			CreateBlocks();
		}

		private void PopulateMatrix()
		{
			nodes.Clear();
			var row = new List<Node> {root};
			nodes.Add(row);
			while (true)
			{
				var nextRow = new List<Node>();
				foreach (var node in row)
					foreach (var child in node.children)
						nextRow.Add(child); // add all children of next row 

				if (nextRow.Count == 0) break; // if there are no children finish
				nodes.Add(nextRow); // create new row
				row = nextRow;
			}
		}

		private void CreateBlocks()
		{
			blocks.Clear();
			var maxColCount = GetMaxColCount();
			var xCenter = position.width / 2f;// maxColCount * (boxSize.x + horiSpacing) / 2f;
			
			for (int r = 0; r < nodes.Count; r++) 
			{
				var row = nodes[r];
				for (int c = 0; c < row.Count; c++)
				{
					// var y = position.height / 2 - vSize / 2f + vertSpacing * j; // middle window pos - half whole size + j idx then
					var x = xCenter - row.Count / 2f + c * horiSpacing; // center - half the pos, then index iterating
					var y = 30f + vertSpacing * r;
					var block = new Block(nodes[r][c]);
					block.rect.center = new Vector2(x, y);
					blocks.Add(block);
					// var vSize = vertSpacing * (r.Count - 1);
					// node.rect.center = new Vector2(x, y);
				}
			}
		}

		private int GetMaxColCount()
		{
			int maxCount = nodes.Select(t => t.Count).Max();
			return maxCount;
		}
		
		// private void SetupNodeRects()
		// {
		// 	nodes.Clear();
		// 	int maxColSize = 0;
		// 	foreach (var col in stagesMatrix)
		// 		maxColSize = col.Count > maxColSize ? col.Count : maxColSize;
		//
		// 	for (int i = 0; i < stagesMatrix.Count; i++)
		// 	{
		// 		var row = stagesMatrix[i];
		// 		for (int j = 0; j < row.Count; j++)
		// 		{
		// 			Node node = nodes.FirstOrDefault(n => n.stage == row[j]);
		// 			if (node == null)
		// 			{
		// 				node = new Node(row[j]);
		// 				nodes.Add(node);
		// 				
		// 				node.stage.OnCompleted -= Repaint; // this here makes window repaint
		// 				node.stage.OnCompleted += Repaint;
		// 				node.stage.OnMarkNotCompleted -= Repaint;
		// 				node.stage.OnMarkNotCompleted += Repaint; 
		// 			}
		//
		// 			var x = horiSpacing * i + 30;
		// 			var vSize = vertiSpacing * (row.Count - 1);
		// 			var y = position.height / 2 - vSize / 2f + vertiSpacing * j; // middle window pos - half whole size + j idx then 
		// 			node.rect.center = new Vector2(x, y);
		// 		}
		// 	}
		//
		// 	OnDrag();
		// }


		private void OnGUI()
		{
			if (GUILayout.Button("rebuild"))
			{
				if (EnableDebugs) Debug.Log($"<color=orange>Rebuilding visual graph</color>");
				offset = Vector2.zero;
			}

			DrawBlocks();
		
			vertSpacing = GUI.VerticalSlider(new Rect(10, 50, 10, 50), vertSpacing, 200f, 50f);
			horiSpacing = GUI.HorizontalSlider(new Rect(16, 42, 50, 10), horiSpacing, 110, 500f);
			EnableDebugs = GUI.Toggle(new Rect(10, 120, 100, 10), EnableDebugs, "Enable debugs");

			if (GUI.changed)
			{
				CreateBlocks();
			}

			DrawGrid(20, 0.2f, Color.gray);
			DrawGrid(100, 0.4f, Color.gray);
			ProcessEvents(Event.current);
			if (GUI.changed) Repaint();
		}

		private void DrawBlocks()
		{
			foreach (var block in blocks)
			{
				block.Draw();
			}
		}

		private void ProcessEvents(Event e)
		{
			switch (e.type)
			{
				case EventType.MouseDown:
					// if (e.button == 1) ProcessContextMenu(e.mousePosition);
					break;
				case EventType.MouseDrag:
					offset += e.delta;
					GUI.changed = true;
					// if (e.button == 0 || e.button == 2 || e.button == 1) OnDrag(); // lmb or scroll btn
					break;
			}
		}
		
		private void DrawNodeCurve(Rect start, Rect end)
		{
			Vector2 startPos = new Vector2(start.x + start.width, start.y + start.height / 2) + offset;
			Vector2 endPos = new Vector2(end.x, end.y + end.height / 2) + offset;
			Vector2 startTan = startPos + Vector2.right * 50;
			Vector2 endTan = endPos + Vector2.left * 50;
			Color shadowCol = new Color(0, 0, 0, 0.06f);
		
			for (int i = 0; i < 3; i++)
				Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 15);
		
			Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 2);
		}
		
		private void DrawGrid(float gridSpacing, float gridOpacity, Color gridColor)
		{
			int widthDivs = Mathf.CeilToInt(position.width / gridSpacing);
			int heightDivs = Mathf.CeilToInt(position.height / gridSpacing);
		
			Handles.BeginGUI();
			Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);
		
			Vector3 newOffset = new Vector3(offset.x % gridSpacing, offset.y % gridSpacing, 0);
		
			for (int i = 0; i < widthDivs; i++)
				Handles.DrawLine(new Vector3(gridSpacing * i, -gridSpacing, 0) + newOffset, new Vector3(gridSpacing * i, position.height, 0f) + newOffset);
		 
			for (int j = 0; j < heightDivs; j++)
				Handles.DrawLine(new Vector3(-gridSpacing, gridSpacing * j, 0) + newOffset, new Vector3(position.width, gridSpacing * j, 0f) + newOffset);
		
			Handles.color = Color.white;
			Handles.EndGUI();
		}
		
	}
}