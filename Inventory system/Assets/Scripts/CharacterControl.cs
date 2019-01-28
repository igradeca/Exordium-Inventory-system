using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    //[Range(0.0f, 2.0f)]
    //public float walkingSpeed;

    public Animator Animator;
    public Rigidbody2D RigidBody;

    // Update is called once per frame
    void FixedUpdate () {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        Animator.SetFloat("Horizontal", movement.x);
        Animator.SetFloat("Vertical", movement.y);
        Animator.SetFloat("Magnitude", movement.magnitude);

        //transform.position = transform.position + movement * Time.deltaTime * walkingSpeed;
        //rigidBody.AddForce(movement * walkingSpeed, ForceMode2D.Force);
        RigidBody.velocity = new Vector2(movement.x, movement.y);
    }


}
