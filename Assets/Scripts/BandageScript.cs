using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandageScript : MonoBehaviour
{
    private static bool itemBool;

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

    // Controll if the nurse took the bandages
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            itemBool = true;
        }
    }
}
