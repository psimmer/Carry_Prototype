using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public Vector3 inventoryPos;
    public float X_Pos;
    public float Y_Pos;
    public InventorySlot itemsDisplayed;
    private GameObject obj = null;
    void Start()
    {
        inventoryPos = transform.position;
        CreateDisplay();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(obj);
            UpdateDisplay();
        } 
    }

    public void UpdateDisplay()
    {
        if (inventory.itemHolder.item && inventory.itemHolder.item != null)
        {
            obj = Instantiate(inventory.itemHolder.item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = Vector3.zero;
            itemsDisplayed = inventory.itemHolder;
        }
    }
    public void CreateDisplay()
    {
        if (itemsDisplayed.item != null)
        {
            obj = Instantiate(inventory.itemHolder.item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(inventoryPos.x - X_Pos, inventoryPos.y - Y_Pos, 0);
        }
    }
}
