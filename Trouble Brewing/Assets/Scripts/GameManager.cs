using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

[Serializable]
public class Enemy
{
    public string name;

    public UnattachableStatsCollection MeleeMinions;
    public UnattachableStatsCollection MageMinions;
    public UnattachableStatsCollection ArcherMinions;

    public UnattachableStatsCollection GetTypeStats(MinionTypes minionType)
    {
        switch (minionType)
        {
            case MinionTypes.Archer: return MeleeMinions;
            case MinionTypes.Mage: return MageMinions;
            case MinionTypes.Melee: return ArcherMinions;
            default: throw new Exception("Unhandled minion type in the Enemy class");
        }
    }
}

/// <summary> A manager used to transfer data between scenes.</summary>
/// <remarks> 
/// This class follows a singleton patern by only allowing one instance.
/// Because of that no data mixup can happen.
/// </remarks>
public class GameManager : MonoBehaviour
{
    public PotionFlags FlaggedPotions;

    public static GameManager Instance;
    public StatsCollection[] StatsCollection;
    public Enemy[] Enemys;
    public int Level = 0;

    public Dialogue DialogueName;

    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)

            //if not, set instance to this
            Instance = this;

        //If instance already exists and it's not this:
        else if (Instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        StatsCollection = GetComponents<StatsCollection>();
        DialogueName = GetComponent<Dialogue>();
    }


}
