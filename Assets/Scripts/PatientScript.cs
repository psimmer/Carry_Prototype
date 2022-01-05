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
    [SerializeField]private GameObject instantiatedPopUp;
    public GameObject InstantiatedPopUp
    {
        get { return instantiatedPopUp; }
        set { instantiatedPopUp = value; }
    }



    [SerializeField] private GameObject myPopUp;
    public GameObject MyPopUp
    {
        get { return myPopUp; }
        set { myPopUp = value; }
    }
    public string Name { get; set; }
    public float PatientHealth { get; set; }
    [SerializeField] private float minTimeTillTask;
    [SerializeField] private float maxTimeTillTask;

    public bool needSomething { get; set; }
    public float randomTime { get; set; }

    [SerializeField] public Task currentTask;

    private void Start()
    {
        needSomething = false;
        instantiatedPopUp = null;
    }
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
        randomTime = Random.Range(minTimeTillTask, maxTimeTillTask);
        return randomTime;
     }



}
