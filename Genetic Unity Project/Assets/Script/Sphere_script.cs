using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_script : MonoBehaviour {

    public float score;
    private float inital_time;

    // Use this for initialization
    void Start () {

        inital_time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        //score is based on time in movement.
        if(this.GetComponent<Rigidbody>().IsSleeping() && score == 0)
            score = Time.time - inital_time;
    }
}
