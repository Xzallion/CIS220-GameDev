using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    //get the current screen pos of mouse
	    Vector3 mousePos2d = Input.mousePosition;
	    mousePos2d.z = -Cameraa.main.ScreentoWorldPoint(mousePos2D);

        //convert the point from 2D screen space into 3d game world peace

	    Vecotr3 mousePos3D = Cameraa.Main.ScreenToWorldPoint(mousePos2D);
        // move the x position o the Basket to the x position of the mouse

        Vector3 pos =  this.transform.position;
        //pos.x = mousePad
	}
}
