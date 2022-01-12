using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//All ItemTypes we have (for the prototpye 2)
public enum ItemType
{
    Bandage,
    Pill                  
}


/// <summary>
/// The description of a default ItemObject
/// </summary>
public class ItemObject : ScriptableObject
{
    [SerializeField] private int restoreHealth;
    [SerializeField] private GameObject prefab;
    [SerializeField] private ItemType itemType;

    public ItemType ItemType
    {
        get { return itemType; }
        set { itemType = value; }
    }

    public int RestoreHealth
    {
        get { return restoreHealth; }
        set { restoreHealth = value; }
    }

    public GameObject Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }
}
