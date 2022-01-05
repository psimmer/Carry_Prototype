using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The description of a Bandage Object
/// </summary>
[CreateAssetMenu(fileName = "Scriptable Objects", menuName = "Items/Bandage")]
public class BandageObj : ItemObject
{
    public int restoreHealth;

    public void Awake()
    {
        itemType = ItemType.Bandage;
    }
}
