using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AppleTree : MonoBehaviour {
    #region class level variables(inspector variables)

    // prefab for instantiation apples
    public GameObject Apple;
    // speed at which the AppleTree moves
    public float speed = 10f;
    // distance where AppleTree turns
    public float leftAndRightEdge = 25f;
    // Chance the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;
    // Rate at which Apple will be instantiated (dropped)
    public float secondsBetweenAppleDrops = 1f;
    #endregion

    // Use this for initialization
    void Start () {
		// dropping apples every second
        Invoke("DropApple", 2f);
    }

    // Drops apples
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(Apple);
        Apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

	// Update is called once per frame
	void Update ()
	{
        // basic movement across the screen
	    Vector3 pos = transform.position;   // save the current position
	    pos.x += speed * Time.deltaTime;
	    transform.position = pos;

        // changing direction
	    if (pos.x < -leftAndRightEdge)
	    {
	        speed = Mathf.Abs(speed);       // Move right
	    }
        else if (pos.x > leftAndRightEdge)
	    {
	        speed = -Mathf.Abs(speed);      // move left
	    }
        
	}

    // Updates 50x a frame according to instructor
    void Fixedupdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
