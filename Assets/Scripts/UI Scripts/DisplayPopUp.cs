using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPopUp : MonoBehaviour
{
    private GameObject cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");

        transform.LookAt(transform.position + cam.transform.forward);
    }

   

}