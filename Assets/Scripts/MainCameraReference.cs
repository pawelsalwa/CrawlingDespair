using System.Collections;
using System.Collections.Generic;
using Character.Teddy;
using ScriptableObjects;
using UnityEngine;

public class MainCameraReference : MonoBehaviour
{

    [SerializeField] private FloatRef cameraRotationY;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        // inputMappingWrapper.InputMapping.Player.
    }

    // Update is called once per frame
    void Update()
    {
        cameraRotationY.Value = cam.transform.rotation.eulerAngles.y;
        // inputMappingWrapper.InputMapping.Player.Look
    }
}
