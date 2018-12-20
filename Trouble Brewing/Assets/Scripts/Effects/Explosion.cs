using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public ParticleSystem Explode;

    //Explosion or any particle effect can be added to gameobject, only need to give spawn position along.
    public void Boom(Vector3 Position)
    {
        var newExp = Instantiate(Explode, Position, Quaternion.identity);
        Destroy(newExp, newExp.main.duration);
    }
}
