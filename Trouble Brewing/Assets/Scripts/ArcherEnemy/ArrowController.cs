using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{
    public TargetingController sender;

    public GameObject minionMan;

    // Use this for initialization
    void Start()
    {
        minionMan = GameObject.Find("MinionManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        //When your archers shoot arrows
        if (sender.CompareTag("Friendly"))
        {
            if (other.CompareTag("Enemy"))
            {
                //Debug.Log("Hit an" + other.gameObject.name);
                var minion = other.GetComponent<TargetingController>();
                minionMan.GetComponent<MinionManager>().DoDamage(sender);
                Destroy(gameObject);
            }
        }
        //When opponents archers shoot arrows
        else if (sender.CompareTag("Enemy"))
        {
            if (other.CompareTag("Friendly"))
            {
                //Debug.Log("Hit an" + other.gameObject.name);
                var minion = other.GetComponent<TargetingController>();
                minionMan.GetComponent<MinionManager>().DoDamage(sender);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
