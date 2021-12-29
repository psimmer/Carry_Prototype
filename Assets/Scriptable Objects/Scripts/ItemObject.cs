using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Bandage,
    Pills,                  //All ItemTypes we have
    Telephone,
    CoffeMachine
}


/// <summary>
/// The description of a default ItemObject
/// </summary>
public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
}