using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {
    
    public AudioSource healSpell;
    public AudioSource fireSpell;

    private static bool sfxManExists;

    // Use this for initialization
    void Start () {

        //makes it so there will always be a sfx manager
        if (!sfxManExists)
        {
            sfxManExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
