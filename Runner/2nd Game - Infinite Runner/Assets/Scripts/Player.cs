using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _jumpHeight = 10.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    private float _yVelocity = 0.0f;
    private float _xPosition;
    private GameObject player;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        _controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        _xPosition = player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        //Direction to Travel (vector3)
        Vector3 direction = new Vector3(0, 0, 1);
        //Velocity = Direction * Speed
        Vector3 velocity = direction * _speed;

        //if canJump
        //velocity on the Y = jumpHeight
        if (_controller.isGrounded == true)
        {
            //if space key
            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
            }

            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    _xPosition -= 1;
            //    transform.Translate(_xPosition);
                
            //}
        }
        else
        {
            //add gravity
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        //Move (Velocity * timeDelta)
        _controller.Move(velocity * Time.deltaTime);
	}
}
