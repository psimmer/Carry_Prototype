using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Objects", menuName = "Items/Pills")]
public class PillsObject : ItemObject
{
    public int restoreHealth;

    private void Awake()
    {
        type = ItemType.Pills;
    }
}
