using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPopUp : MonoBehaviour
{
    [SerializeField] private GameObject cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");

        // PopUp looks to camera
        transform.LookAt(transform.position + cam.transform.forward);
    }
}