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
    }

    void Update()
    {
            Destroy(obj);
            UpdateDisplay();
    }

    /// <summary>
    /// checks if the item is null and checks if the PlayerScript trigger triggers an item, after this we Instantiate the triggert itemPrefab
    /// </summary>
    public void UpdateDisplay()
    {
        if (inventory.itemHolder.item && inventory.itemHolder.item != null)
        {
            obj = Instantiate(inventory.itemHolder.item.Prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = Vector3.zero;
            itemsDisplayed = inventory.itemHolder;
        }
    }
}
