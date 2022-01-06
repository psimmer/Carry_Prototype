using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public Vector3 inventoryPos;
    public InventorySlot itemsDisplayed;
    private GameObject obj = null;
    void Start()
    {
        inventoryPos = transform.position;
        CreateDisplay();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            Destroy(obj);
            UpdateDisplay();
        //} 
    }

    // checks if the item is null and checks if the PlayerScript trigger triggers an item,
    //after this we Instantiate the triggert itemPrefab.
    public void UpdateDisplay()
    {
        if (inventory.itemHolder.item && inventory.itemHolder.item != null)
        {
            obj = Instantiate(inventory.itemHolder.item.Prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = Vector3.zero;
            itemsDisplayed = inventory.itemHolder;
        }
    }

    // If the itemSlot is not null at the beginning we Instantiate the item we already have.
    public void CreateDisplay()
    {
        if (itemsDisplayed.item != null)
        {
            obj = Instantiate(inventory.itemHolder.item.Prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }
}
