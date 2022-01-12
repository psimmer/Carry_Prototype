using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System")]
public class InventoryObject : ScriptableObject
{
    public InventorySlot itemHolder;

    //The InventorySlot gets an item --->> look in class InventorySlot
    public void AddItem(ItemObject item)
    {
            itemHolder.item = item;
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;     

    public InventorySlot(ItemObject this_item)
    {
        item = this_item;
    }
}