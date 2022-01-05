using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Task
{
    Wound,
    Pain
}

public class PatientScript : MonoBehaviour
{


    public string Name { get; set; }
    public float PatientHealth { get; set; }
    [SerializeField]
    public bool needSomething { get; set; }
    public float randomTime { get; set; }

    [SerializeField]
    public Task currentTask;


    //public PatientScript(float health, string name, ItemType _item)
    //{
    //    Name = name;
    //    PatientHealth = health;
    //    item = _item;
    //}

    //public PatientScript(float health, string name)
    //{
    //    Name = name;
    //    PatientHealth = health;
    //}


    //maybe we use an independet script for the random time (Patrick)
    public float GetRandomTime()
     {
        randomTime = Random.Range(10, 20);
        return randomTime;
     }



}
