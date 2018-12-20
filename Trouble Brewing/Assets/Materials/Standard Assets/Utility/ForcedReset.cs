using System;
using UnityEngine;
using SM = UnityEngine.SceneManagement ;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (GUITexture))]
public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // if we have forced a reset ...
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            //... reload the scene
            SM.SceneManager.LoadScene(SceneHelper.ActiveSceneID);
        }
    }
}