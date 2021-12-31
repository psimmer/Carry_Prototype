using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed;

    private float horizontalMovement;
    private float verticalMovement;
    Transform playerTransform;
    void Start()
    {
        playerTransform = gameObject.transform;
    }
    void FixedUpdate()
    {
        playerMovement();
    }


    void playerMovement()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        if (Mathf.Abs(horizontalMovement) > 0.17 || Mathf.Abs(verticalMovement) > 0.17)
        {
            playerTransform.rotation = Quaternion.LookRotation(movement);
        }
        playerTransform.Translate(movement * playerMovementSpeed * Time.deltaTime, Space.World);


    }
}