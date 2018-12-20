using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour {

    private StatsCollection _potionStats;

    void Start()
    {
        _potionStats = GetComponent<StatsCollection>();
    }
    
    //this method is given value in the child classes of potion so that OnCollisionEnter isnt rewritten for each different child class.
    public void CollisionAction(Collision col)
    {
        col.gameObject.GetComponent<MinionController>().Stats.AddToStats(_potionStats);
        Debug.Log("I feel different!");
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "minion")
        {
            Debug.Log("Potion hit!");
            CollisionAction(col);
            Destroy(gameObject);
        }
    }
}
