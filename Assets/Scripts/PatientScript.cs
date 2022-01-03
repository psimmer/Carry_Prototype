using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientScript
{
    public string Name { get; set; }
    public float PatientHealth { get; set; }
    public bool needSomething { get; set; }
    public float randomTime { get; set; }

    private ItemType item;
    public ItemType Item
    {
        get
        {
            return item;
        }
        set
        {
            item = value;
        }
    }


    public PatientScript(float health, string name, ItemType _item)
    {
        Name = name;
        PatientHealth = health;
        item = _item;
    }
       

    //maybe we use an independet script for the random time (Patrick)
     public float GetRandomTime()
     {
        randomTime = Random.Range(10, 20);
        return randomTime;
     }



}
