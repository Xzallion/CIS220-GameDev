using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocketship : MonoBehaviour {
    [SerializeField] float rocketThrust = 125f;
    [SerializeField] float rocketRotation = 50f;
    Rigidbody rigidbody;
    AudioSource rocketThrustSND;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rocketThrustSND = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ActivateThrusters();
        ShutdownThrusters();
        RCS();
	}

    public void ActivateThrusters()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrust up");
            rigidbody.AddRelativeForce(Vector3.up * rocketThrust);

            if (!rocketThrustSND.isPlaying)
            {
                rocketThrustSND.Play();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Friendly")
        {
            Debug.Log("Lost!");
            SceneManager.LoadScene("Level01");
        }
        else if(collision.gameObject.name == "Finish")
        {
            Debug.Log("Finish!");
            SceneManager.LoadScene("Level02");
        }
    }

    /// <summary>
    /// Stops the audio for rocket thrust when Space is released
    /// </summary>
    public void ShutdownThrusters()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rocketThrustSND.Stop();
        }
    }

    public void RCS()
    {
        rigidbody.freezeRotation = true;
        float rotationThisFrame = rocketThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotating left");
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotating right");
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidbody.freezeRotation = false;
    }
}
