using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float playerRotationSpeed;
    Transform playerTransform;
    void Start()
    {
        playerTransform = gameObject.transform;
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerTransform.Translate(Vector3.forward * playerMovementSpeed * Time.deltaTime);
        }        
        if(Input.GetKey(KeyCode.S))
        {
            playerTransform.Translate(Vector3.back * playerMovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(Vector3.up * playerRotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.Rotate(Vector3.down * playerRotationSpeed * Time.deltaTime);
        }

        // We should use the other type of movement (with the input from -1 to 1) because this one doesnt feel as smooth.
        // I will change it later on/tomorrow, but I used this one to test the scene.

        // I think we should use box colliders on the patients that are bigger than the collider from the model itself. 
        // This way, we would be able to detect a collision between the player and a patient that has an active task, and allow the interaction 
        // with space.

    }
}
