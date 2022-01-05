using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The description of a Pill Objekt
/// </summary>
[CreateAssetMenu(fileName = "Scriptable Objects", menuName = "Items/Pills")]
public class PillsObject : ItemObject
{
    public int restoreHealth;

    private void Awake()
    {
        itemType = ItemType.Pill;
    }
}
