using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
    public GameObject CubePrefabVar;

	// Use this for initialization
	void Start () {
        //Instantiate(CubePrefabVar);	
	}
	
	// Update is called once per frame
	void Update () {
        Instantiate(CubePrefabVar);
    }
}
