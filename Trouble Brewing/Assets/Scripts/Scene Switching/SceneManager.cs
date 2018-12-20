using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySM = UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
    public bool IsBusyLoading { get { return _busyLoading; } }

    private bool _busyLoading = false;

    public void SwitchSceneSpell()
    {
        if (SceneHelper.ActiveSceneID == SceneHelper.Arena)
        {
            //Debug.LogAssertionFormat("Active scene: {0}\nArena Scene: {1}\nMage Scene: {2}",SceneHelper.ActiveSceneID,SceneHelper.Arena,SceneHelper.MageTower);
            StartCoroutine(LoadScene(SceneHelper.MageTower));
        }
        else if (SceneHelper.ActiveSceneID == SceneHelper.MageTower)
        {
            StartCoroutine(LoadScene(SceneHelper.Arena));
        }
        else
        {
            throw new System.Exception("The current active scene is not recognised. Please check the SceneHelper or check if there is a check for the active scene in the GameManager script.");
        }
    }

    public void IntroSwitchScene()
    {
        StartCoroutine(LoadScene(SceneHelper.MageTower));
        if(!GameManager.Instance.DialogueName.Flags.CheckFlags(DialogueFlags.FirstTeleport))
        {
            FindObjectOfType<AudioManager>().Play("FirstTeleport");
        }
    }


    /// <summary> A coroutine which will load start loading a scene if no scene is busy loading.</summary>
    /// <param name="SceneIndex"> The build index of the scene you want to load.</param>
    IEnumerator LoadScene(int SceneIndex)
    {
        if (_busyLoading) yield return null;
        if (SceneIndex == -1) throw new System.Exception("Illegal build index, The scene you are trying to acces does not appear in the build settings.");


        AsyncOperation asyncLoad = UnitySM.SceneManager.LoadSceneAsync(SceneIndex);

        _busyLoading = true;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        _busyLoading = false;
    }

    IEnumerator LoadScene(string SceneIndex)
    {
        if (_busyLoading) yield return null;



        AsyncOperation asyncLoad = UnitySM.SceneManager.LoadSceneAsync(SceneIndex);

        _busyLoading = true;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        _busyLoading = false;
    }
}
