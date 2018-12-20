using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unitySM = UnityEngine.SceneManagement;


/// <summary> A helper class to save performance when loading scenes by caching the scene indices</summary>
public static class SceneHelper {
    // The scenes available to the helper class
    // To add a scene, make a public static int field that gets it's value from the scene the scene manager fetched.
    // Example:
    // public static int SceneOne = SceneUtility.GetBuildIndexByScenePath("Scene 1");

    // TODO:
    // Add all scenes

    /// <summary> Returns the build index ID of the current active scene.</summary>
    public static int ActiveSceneID { get { return unitySM.SceneManager.GetActiveScene().buildIndex; } }

    public static readonly int MageTower = unitySM.SceneUtility.GetBuildIndexByScenePath("MageTower");
    public static readonly int Arena = unitySM.SceneUtility.GetBuildIndexByScenePath("TroubleBrewingArena");
    public static readonly int Introduction = unitySM.SceneUtility.GetBuildIndexByScenePath("Introduction");
}