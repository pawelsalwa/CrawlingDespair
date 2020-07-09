using System.Collections;
using System.Collections.Generic;
using Character.Teddy;
using Cinemachine;
using UnityEngine;

public class OrbitCameraInputProvider : MonoBehaviour
{
	[SerializeField] private CinemachineFreeLook cinemachineFreeLook;
	[SerializeField] private InputMappingWrapper input;
	[SerializeField] private float speedX = 1f;
	[SerializeField] private float speedY = 1f;

	private void Start()
	{
		cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
	}

	public void MoveCamera(Vector2 val)
	{
		var newAxisX = cinemachineFreeLook.m_XAxis;
		newAxisX.Value += val.x * speedX * Time.deltaTime;
		cinemachineFreeLook.m_XAxis = newAxisX;

		var newAxisY = cinemachineFreeLook.m_YAxis;
		newAxisY.Value += val.y * speedY * Time.deltaTime;
		cinemachineFreeLook.m_YAxis = newAxisY;
	}


	private void LateUpdate()
	{
		MoveCamera(input.InputMapping.Player.Look.ReadValue<Vector2>());
	}
}