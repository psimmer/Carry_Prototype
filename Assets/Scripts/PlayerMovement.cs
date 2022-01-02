using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float maxSpeed;

    private float horizontalMovement;
    private float verticalMovement;
    private float verticalRotation;
    private float horizontalRotation;
    Rigidbody playerRigidbody;
    Transform playerTransform;
    Vector3 maxSpeedVector;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = gameObject.transform;
        maxSpeedVector = new Vector3(maxSpeed, 0f, maxSpeed);
    }
    void FixedUpdate()
    {
        playerMovement();
    }


    void playerMovement()
    {
        horizontalRotation = Input.GetAxis("Horizontal");
        verticalRotation = Input.GetAxis("Vertical");
        horizontalMovement = 0;
        verticalMovement = 0;

        if (Input.GetKey(KeyCode.W))
        {
            verticalMovement = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            verticalMovement = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMovement = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalMovement = 1f;
        }



        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        Vector3 rotation = new Vector3(horizontalRotation, 0f, verticalRotation);
        movement = movement.normalized * Time.deltaTime * playerMovementSpeed;

        // if the axis input is higher than 0.17 (number pulled out of my ass, but it works nicely)
        // then rotate player in the direction of the input. Without this number, it will start rotating constantly.
        if (Mathf.Abs(horizontalMovement) > 0.17 || Mathf.Abs(verticalMovement) > 0.17)
        {
            playerTransform.rotation = Quaternion.LookRotation(rotation);
        }

        // check if current velocity is lower than max speed, if so, you can keep adding force 
        if (playerRigidbody.velocity.magnitude < maxSpeed)
        {
            playerRigidbody.AddForce(movement);
        }

    }
}