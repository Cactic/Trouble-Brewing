using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemyAttack : MonoBehaviour
{

    public GameObject Arrow_Emitter;
    public GameObject Arrow;
    public float Arrow_Forward_Force;

    GameObject Temporary_Arrow_Handler;

    TargetingController targetCon;

    public void Start()
    {
        targetCon = FindObjectOfType<TargetingController>();
    }

    public void ShootArrow(TargetingController sender, GameObject shooter)
    {
        //Instantiate the arrow
        Temporary_Arrow_Handler = Instantiate(Arrow, Arrow_Emitter.transform.position, Arrow_Emitter.transform.rotation) as GameObject;
        //If the arrow is laying wrong, rotate it right
        Temporary_Arrow_Handler.transform.Rotate(Vector3.left * 90);
        //Control the rigidbody of the arrow
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Arrow_Handler.GetComponent<Rigidbody>();
        var arrowController = Temporary_Arrow_Handler.GetComponent<ArrowController>();
        arrowController.sender = sender;

        //Let the arrow fly forwards
        Temporary_RigidBody.AddForce(transform.forward * Arrow_Forward_Force);
        //If the arrow did not hit anything, destroy after 10 sec
        Destroy(Temporary_Arrow_Handler, 4.0f);
    }
}
