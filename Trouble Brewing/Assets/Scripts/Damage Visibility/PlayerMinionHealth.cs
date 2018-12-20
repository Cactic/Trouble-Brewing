using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMinionHealth : MonoBehaviour {

    private float minionMaxHealth = 10;
    public float minionHealth;
    public float damageDone;

    public Material[] material;
    Renderer rend;
    public ParticleSystem part;
    
    // Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        part = GetComponent<ParticleSystem>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
	}
	
	// Update is called once per frame
	void Update () {
        minionHealth = minionMaxHealth - damageDone;
        //Changing material on certain health levels
        if (minionHealth == (minionMaxHealth / 100 * 90) || minionHealth == (minionMaxHealth / 100 * 80))
        {
            rend.sharedMaterial = material[1];
        }
        else if (minionHealth == (minionMaxHealth / 100 * 70) || minionHealth == (minionMaxHealth / 100 * 60))
        {
            rend.sharedMaterial = material[2];
        }
        else if (minionHealth == (minionMaxHealth / 100 * 50) || minionHealth == (minionMaxHealth / 100 * 40))
        {
            rend.sharedMaterial = material[3];
        }
        else if (minionHealth == (minionMaxHealth / 100 * 30) || minionHealth == (minionMaxHealth / 100 * 20)
          || minionHealth == (minionMaxHealth / 100 * 10))
        {
            rend.sharedMaterial = material[4];
        }
        else if (minionHealth == (minionMaxHealth / 100 * 0) || minionHealth < (minionMaxHealth / 100 * 0))
        {
            rend.sharedMaterial = material[5];
        }
    }
}
