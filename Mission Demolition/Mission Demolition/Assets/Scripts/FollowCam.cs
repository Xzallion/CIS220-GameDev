using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // The Static point of interest

    [Header("Set Dynamically")]
    public float camZ;

	// Use this for initialization
	void Start ()
	{
	    camZ = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
	{
	   
	}

    void FixedUpdate()
    {
        if (POI == null) return; //Bad bad code

        // get hte position of the POI
        Vector3 destination = POI.transform.position;
        // force destination.z to be camZ to keep the camera far enough away!
        destination.z = camZ;
        transform.position = destination;
    }
}
