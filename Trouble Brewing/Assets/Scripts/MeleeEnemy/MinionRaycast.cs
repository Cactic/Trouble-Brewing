using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinionRaycast : MonoBehaviour {
    

    TargetingController tController;

    int knockbackPower;

    void Start()
    {
        tController = GetComponent<TargetingController>();
        knockbackPower = 2;
    }
}
