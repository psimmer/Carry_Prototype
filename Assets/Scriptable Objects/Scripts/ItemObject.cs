using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Bandage,
    Pill,                  //All ItemTypes we have
    Telephone,
    CoffeMachine
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
