using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionManager : MonoBehaviour, iMinionManager
{
    #region Minion prafabs, spawnpoints, amounts and variable
    public GameObject friendlyMeleePrefab; // prefab of the melee Minion
    public GameObject friendlyMagePrefab; // prefab of the mage Minion
    public GameObject friendlyArcherPrefab; // prefab of the archer Minion

    public GameObject enemyMeleePrefab; // prefab of the enemy minion
    public GameObject enemyMagePrefab; // prefab of the enemy minion
    public GameObject enemyArcherPrefab; // prefab of the enemy minion

    public GameObject friendlyMeleeSpawnPoint; // spawnpoint of the enemy minion
    public GameObject friendlyMageSpawnPoint; // spawnpoint of the enemy minion
    public GameObject friendlyArcherSpawnPoint; // spawnpoint of the enemy minion

    public GameObject enemyMeleeSpawnPoint; // spawnpoint of the enemy minion
    public GameObject enemyMageSpawnPoint; // spawnpoint of the enemy minion
    public GameObject enemyArcherSpawnPoint; // spawnpoint of the enemy minion

    public List<iAI> enemyMinions = new List<iAI>(); // list with enemy minions
    public List<iAI> friendlyMinions = new List<iAI>(); // list with friendly minions

    int friendlyMeleeAmount = 5;
    int friendlyMageAmount = 5;
    int friendlyArcherAmount = 5;

    int enemyMeleeAmount = 5;
    int enemyMageAmount = 5;
    int enemyArcherAmount = 5;

    float distanceFromFriendly;
    float distanceFromEnemy;

    TargetingController controller;
    MinionRaycast meleeMinion;
    #endregion

    // Loop for all the minion types to instantiat.
    private void SpawnMinions(GameObject prefab, int unitSize, GameObject spawnPointObject, List<iAI> army)
    {
        for (int i = 0; i < unitSize; i++)
        {
            GameObject friendOrFoe = Instantiate(prefab, new Vector3(spawnPointObject.transform.position.x
               , spawnPointObject.transform.position.y, spawnPointObject.transform.position.z), Quaternion.identity);
            controller = friendOrFoe.GetComponent<TargetingController>();
            army.Add(controller);

            //keep reference of the coroutine.
            controller.AttackRoutine = StartCoroutine(Attack(controller));
        }
    }

    void Start()
    {
        StartCoroutine(Timer());

        meleeMinion = GetComponent<MinionRaycast>();

        //instantiate friendly melee minion
        SpawnMinions(friendlyMeleePrefab, friendlyMeleeAmount, friendlyMeleeSpawnPoint, friendlyMinions);

        //instantiate friendly mage minion
        SpawnMinions(friendlyMagePrefab, friendlyMageAmount, friendlyMageSpawnPoint, friendlyMinions);

        //instantiate friendly archer minion
        SpawnMinions(friendlyArcherPrefab, friendlyArcherAmount, friendlyArcherSpawnPoint, friendlyMinions);

        //instantiate Enemy Melee minion
        SpawnMinions(enemyMeleePrefab, enemyMeleeAmount, enemyMeleeSpawnPoint, enemyMinions);

        //instantiate Enemy mage minion
        SpawnMinions(enemyMagePrefab, enemyMageAmount, enemyMageSpawnPoint, enemyMinions);

        //instantiate Enemy archer minion
        SpawnMinions(enemyArcherPrefab, enemyArcherAmount, enemyArcherSpawnPoint, enemyMinions);
    }

    /// <summary>Check if there are targets to remove.</summary>
    /// <param name="caller">Minion who calls this methode.</param>
    public void CheckToRemovetarget(iAI caller)
    {
        iAI target = caller.Target;
        if (target.StatsCol.Health <= 0)
        {
            // Check if all any side is dead, if so stop damaging and looping to search targets
            if (friendlyMinions.Count <= 0 || enemyMinions.Count <=0)
            {
                StopAllCoroutines();
                return;
            }

            switch (target.Faction)
            {
                case Alliance.Enemy:
                    enemyMinions.Remove(target);
                    break;

                case Alliance.Player:
                    friendlyMinions.Remove(target);
                    break;
            }
        }
    }

    /// <summary>Assign a new target evertime Timer is called.</summary>
    /// <param name="caller">The Minion that calls this Method.</param>
    private void AssignTarget(iAI caller)
    {
        //distance is infinity so it will always get a distance later that is lower to make its new target
        float distance = float.PositiveInfinity;
        switch (caller.Faction)
        {
            case Alliance.Enemy:
                foreach (iAI friendlies in friendlyMinions)
                {
                    distanceFromFriendly = Vector3.Distance(caller.Location, friendlies.Location);
                    if (distanceFromFriendly < distance)
                    {
                        distance = distanceFromFriendly;
                        caller.Target = friendlies;
                    }
                }
                break;
            case Alliance.Player:
                foreach (iAI enemies in enemyMinions)
                {
                    distanceFromEnemy = Vector3.Distance(caller.Location, enemies.Location);
                    if (distanceFromEnemy < distance)
                    {
                        distance = distanceFromEnemy;
                        caller.Target = enemies;
                    }
                }
                break;
            default: throw new System.Exception("Geen target gevonden");
        }
    }

    /// <summary>A timer that calls every 1 second the AssignTarget method.</summary>
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        foreach (iAI friendlyMinion in friendlyMinions)
        {
            AssignTarget(friendlyMinion);
        }

        foreach (iAI enemyMinion in enemyMinions)
        {
            AssignTarget(enemyMinion);
        }

        StartCoroutine(Timer());
    }

    /// <summary>when the target is attacking, wait for the attackspeed amount.</summary>
    public IEnumerator Attack(TargetingController targetingController)
    {
        while (true)
        {
            if (targetingController.IsInRange)
            {
                DoDamage(targetingController);
                yield return new WaitForSeconds(targetingController.StatsCol.AttackSpeed);
            }
            yield return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>Damages the callers target</summary>
    /// <param name="caller">The minion that calls this method.</param>
    public void DoDamage(iAI caller)
    {
        if (caller.IsInRange)
        {
            caller.Target.StatsCol.Health -= caller.StatsCol.AttackPower;
            CheckToRemovetarget(caller);
        }
    }
}
