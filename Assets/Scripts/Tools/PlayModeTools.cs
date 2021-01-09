using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using GameCore;
using UnityEditor;
using UnityEngine;

public class PlayModeTools : MonoBehaviour
{

    // public GameState GameState;

    // Update is called once per frame
    void Update()
    {
        // if (UnityEngine.Input.GetKeyDown(KeyCode.X))
        //     CleanUnityConsole();
        //
        // if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        //     GameState.TogglePause();
        
    }
    
    public static void CleanUnityConsole()
    {
#if UNITY_EDITOR
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
#endif
    }
}
