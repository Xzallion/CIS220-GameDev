using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;

    public int numBaskets = 3;

    public float basketBottomY = -14f;

    public float basketSpacingY = 2f;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y basicBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = POS;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
