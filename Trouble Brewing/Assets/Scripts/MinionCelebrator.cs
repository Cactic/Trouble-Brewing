using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinionCelebrator : MonoBehaviour
{

    public void Celebrate()
    {
        Debug.Log("celebrated");
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 20, 0));
    }
}
