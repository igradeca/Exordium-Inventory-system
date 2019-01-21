using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    [Range(0.0f, 2.0f)]
    public float walkingSpeed;

    public Animator animator;
    public Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        //transform.position = transform.position + movement * Time.deltaTime * walkingSpeed;
        //rigidBody.AddForce(movement * walkingSpeed, ForceMode2D.Force);
        rigidBody.velocity = new Vector2(movement.x, movement.y);
    }


}
