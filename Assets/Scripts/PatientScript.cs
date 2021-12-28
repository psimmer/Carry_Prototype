using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientScript
{
    public string Name { get; set; }
    public float patientHealth { get; set; }
    public bool needSomething { get; set; }
    public float randomTime { get; set; }

    public PatientScript(float health, string name)
    {
        Name = name;
        patientHealth = health;
    }

     public float GetRandomTime()
    {
        randomTime = Random.Range(10, 20);
        return randomTime;
    }



}
