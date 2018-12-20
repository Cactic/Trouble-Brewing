using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    public StatsCollection Stats { get; private set; }

	// Use this for initialization
	void Start ()
    {
        Stats = GetComponent<StatsCollection>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
