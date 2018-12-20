using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemyAttack : MonoBehaviour {

    public float apertureAngle;
    public float maxSightDistance;
    public int iterations;
    private GameObject _lineOfSightGo;

    public Transform Target;
    int MoveSpeed = 2;
    int MaxDist = 10;
    int MinDist = 5;

    public GameObject Magic_Emitter;
    public GameObject Magic;
    public float Magic_Forward_Force;
    public float timeBetweenShots = 1;
    private float timeStamp;

    private PlayerMinionHealth thePlayer;

    GameObject Temporary_Magic_Handler;

    void Start()
    {
        _lineOfSightGo = new GameObject("LineOfSight");
        _lineOfSightGo.AddComponent<MeshFilter>();
        _lineOfSightGo.AddComponent<MeshRenderer>();
        _lineOfSightGo.GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));

        thePlayer = FindObjectOfType<PlayerMinionHealth>();
    }

    void Update()
    {
        _lineOfSightGo.GetComponent<MeshFilter>().mesh = GenerateSightMesh(iterations);
    }

    //Creating field of view and checking incomming
    Mesh GenerateSightMesh(int iterations)
    {
        Mesh m = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        Vector3 startingPoint = transform.position;
        vertices.Add(startingPoint);
        float angleStep = apertureAngle / iterations;
        RaycastHit hit;

        //Field of view
        for (int i = 0; i <= iterations; i++)
        {
            float angle = (-apertureAngle * 0.5f) + (i * angleStep);
            Vector3 sightVector = Quaternion.AngleAxis(angle, transform.up) * transform.forward;
            if (Physics.Raycast(startingPoint, sightVector, out hit, maxSightDistance))
            {
                vertices.Add(startingPoint + sightVector * hit.distance);
                //If a player minion is in sight
                if (hit.collider.tag == "PlayerMinion")
                {
                    Target = hit.collider.transform;
                    Attack();
                }
            }
            else
            {
                vertices.Add(startingPoint + sightVector * maxSightDistance);
            }
            if (i >= 1)
            {
                triangles.Add(0);
                triangles.Add(i);
                triangles.Add(i + 1);
            }
        }
        m.vertices = vertices.ToArray();
        m.triangles = triangles.ToArray();
        return m;
    }

    //Shoot magic to the found player minion
    public void Attack()
    {
        transform.LookAt(Target); //Look at the found player minion

        //If the player minion is in sight
        if (Vector3.Distance(transform.position, Target.position) >= MinDist)
        {
            if (Vector3.Distance(transform.position, Target.position) <= MaxDist)
            {
                Debug.Log("I CAN SEE YOU, ATTACK!!!");

                if (Time.time >= timeStamp)
                {
                    //Instantiate the magic
                    Temporary_Magic_Handler = Instantiate(Magic, Magic_Emitter.transform.position, Magic_Emitter.transform.rotation) as GameObject;
                    //If the magic is laying wrong, rotate it right
                    Temporary_Magic_Handler.transform.Rotate(Vector3.left * 90);
                    //Control the rigidbody of the magic
                    Rigidbody Temporary_RigidBody;
                    Temporary_RigidBody = Temporary_Magic_Handler.GetComponent<Rigidbody>();
                    //Let the magic fly forwards
                    Temporary_RigidBody.AddForce(transform.forward * Magic_Forward_Force);
                    //If the magic did not hit anything, destroy after 10 sec
                    Destroy(Temporary_Magic_Handler, 10.0f);
                    //Time between shot magic
                    timeStamp = Time.time + timeBetweenShots;
                }
            }
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "PlayerMinion":
                thePlayer.damageDone++;
                thePlayer.part.Emit(15);
                break;

            case "EnemyMinion":
                Debug.Log("Hello!");
                break;
        }
    }
}
