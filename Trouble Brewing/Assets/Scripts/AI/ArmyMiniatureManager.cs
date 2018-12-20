using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyMiniatureManager : MonoBehaviour
{
    public MinionTypes StatueType;

   public AudioSource shatterGlass;

    void Start()
    {
        shatterGlass = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Als een potion collide met de statue geeft het de stat changes aan de minionType die je de statue hebt gegeven
        if (collision.gameObject.tag == "Potion")
        {
            GameManager.Instance.StatsCollection[(byte)StatueType].AddToStats(
            collision.gameObject.GetComponent<StatsCollection>());
            shatterGlass.Play();


            Debug.Log("Added a potion to the GameManager's StatsCollection.");

            Destroy(collision.gameObject);
        }
    }
}
