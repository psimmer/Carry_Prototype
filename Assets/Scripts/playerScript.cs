using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public InventoryObject inventory;

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item)
        {
            inventory.itemHolder.item = null;
        }
    }
    private void OnApplicationQuit()
    {
        inventory.itemHolder = null;
    }
}
