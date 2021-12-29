using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Objects", menuName = "Items/Bandage")]

public class BandageObj : ItemObject
{
    public int restoreHealth;

    public void Awake()
    {
        type = ItemType.Bandage;
    }
}
