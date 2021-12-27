using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandageScript : MonoBehaviour
{
    private static bool itemBool;
    private bool onTrigger;
    //boolean goes to PopUpScript
    public bool ItemBool
    {
        get { return itemBool; }
        set { itemBool = value; }
    }

    void Start()
    {
        itemBool = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onTrigger)
        {
            Debug.Log("You took Bandages");

            itemBool = true;
        }
    }


    // Controll if the nurse took the bandages
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTrigger = true;
        }
    }
}
