using System;
using System.Collections.Generic;
using System.Linq;
using Character.Teddy;
using UnityEngine;

public class TransparentWallsRaycasting : MonoBehaviour {

	public List<MeshRenderer> transparentRenderers = new List<MeshRenderer>();

	public PawnTeddy teddy;
	public LayerMask layerMaskEnviro;
	
	public Renderer wallsRenderer;
	public Material wallsSharedMaterial => wallsRenderer.sharedMaterial;

	/// <summary> from pos is behind camera to make sure raycast from it hits all needed colliders </summary>
	private Vector3 fromPos => Camera.main.transform.position - Camera.main.transform.forward.normalized;

	private Vector3 targetPos => teddy.transform.position + Vector3.up;
	private Vector3 targetDirCenter => targetPos - fromPos;
	private Vector3 targetDirLeft => teddy.transform.position - teddy.transform.right * 2f - fromPos + Vector3.up;
	private Vector3 targetDirRight => teddy.transform.position + teddy.transform.right * 2f - fromPos + Vector3.up;

	private Vector3 targetDirLeft2 => teddy.transform.position - teddy.transform.right * 4f - fromPos + Vector3.up;
	private Vector3 targetDirRight2 => teddy.transform.position + teddy.transform.right * 4f - fromPos + Vector3.up;

	private float distanceToPlayer => Vector3.Magnitude(fromPos - targetPos);

	private void Update() {
		// if (GM.instance?.mainCamera == null || teddy == null) return;

		var pos = teddy.transform.position;
		Vector4 playerPos4 = new Vector4(pos.x, pos.y, pos.z, 0f);

		var dir = teddy.transform.forward;
		Vector4 playerDir4 = new Vector4(dir.x, dir.y, dir.z, 0f);

		wallsSharedMaterial.SetVector("_playerPos", playerPos4);
		wallsSharedMaterial.SetVector("_playerDir", playerDir4);

		ResetRenderers();

		Debug.DrawRay(fromPos, targetDirCenter, Color.cyan, Time.deltaTime, true);
		Debug.DrawRay(fromPos, targetDirLeft, Color.cyan, Time.deltaTime, true);
		Debug.DrawRay(fromPos, targetDirRight, Color.cyan, Time.deltaTime, true);
		Debug.DrawRay(fromPos, targetDirLeft2, Color.cyan, Time.deltaTime, true);
		Debug.DrawRay(fromPos, targetDirRight2, Color.cyan, Time.deltaTime, true);

		if (!IsCameraBehindWall()) { return; }

		bool hit1 = Physics.Raycast(fromPos, targetDirCenter,  out var hitInfos, layerMaskEnviro);
		bool hit2 = Physics.Raycast(fromPos, targetDirLeft,  out var hitInfos1, layerMaskEnviro);
		bool hit3 = Physics.Raycast(fromPos, targetDirRight,  out var hitInfos2, layerMaskEnviro);
		bool hit4 = Physics.Raycast(fromPos, targetDirLeft2,  out var hitInfos3, layerMaskEnviro);
		bool hit5 = Physics.Raycast(fromPos, targetDirRight2,  out var hitInfos4, layerMaskEnviro);

//		if (hitInfos.Length == 0) return;

		if (hit1) SetTransparentOnMaterials(hitInfos);
		if (hit2) SetTransparentOnMaterials(hitInfos1);
		if (hit3) SetTransparentOnMaterials(hitInfos2);
		if (hit4) SetTransparentOnMaterials(hitInfos3);
		if (hit5) SetTransparentOnMaterials(hitInfos4);
	}

	private bool IsCameraBehindWall()
	{
		var xd = Physics.Raycast(fromPos, targetDirCenter, out var hitInfo, distanceToPlayer, layerMaskEnviro);
		
		return xd;
	}

	private void SetTransparentOnMaterials(RaycastHit hitInfo) {

//		foreach (var hitInfo in hitInfos) {
			// if (hitInfo.transform.gameObject.layer != layerMaskEnviro)
			// 	return;

			var newRenderer = hitInfo.transform.gameObject.GetComponent<MeshRenderer>();
			if (transparentRenderers.Contains(newRenderer))
				return;

			transparentRenderers.Add(newRenderer);
			var mpBlock = new MaterialPropertyBlock();
			mpBlock.SetInt("_isWorking", 1);
			newRenderer.SetPropertyBlock(mpBlock);
//		}
	}

	private void ResetRenderers() {
		foreach (var rend in transparentRenderers) {
			try {
				var mpBlock = new MaterialPropertyBlock();
				mpBlock.SetInt("_isWorking", 0);
				rend.SetPropertyBlock(mpBlock);
			} catch (Exception) { }
		}

		transparentRenderers.Clear();
	}

}