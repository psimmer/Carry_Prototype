using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Bandage,
    Pills,
    Telephone,
    CoffeMachine
}

public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(10, 20)] public string description;
}
