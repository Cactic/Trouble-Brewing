using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewStirring : MonoBehaviour {

    int BrewisStirred;
    int stirringBrew;

    CauldronManager createPotion;

	void Start () {
        BrewisStirred = 15;

        createPotion = GameObject.FindWithTag("Cauldron").GetComponent<CauldronManager>();
    }
	
	void Update () {
		if (stirringBrew >= BrewisStirred)
        {
            stirringBrew = 0;
            createPotion._createPotion = true;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladel"))
        {
            stirringBrew++;
        }
    }
}
