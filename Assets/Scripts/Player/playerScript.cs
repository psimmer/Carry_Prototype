using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public InventoryObject inventory;
    public bool popUpBool { get; set; }

    //Getting the itemType about the Component of the item what we are triggering,
    //and adding the item in our InventorySlot in the InventoryObject.cs
    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item);
        }
        if (other.gameObject.CompareTag("Patient"))
        {
            popUpBool = true;
            Debug.Log("true");
        }
    }
    // We lose the connectivity to the item which we was triggering and set itemholder to null
    private void OnTriggerExit(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item)
        {
            inventory.itemHolder.item = null;
        }
        if (other.gameObject.CompareTag("Patient"))
        {
            popUpBool = false;
            Debug.Log("false");
        }
    }

    // If we end the Application the itemholder set to null
    private void OnApplicationQuit()
    {
        inventory.itemHolder = null;
    }
}
