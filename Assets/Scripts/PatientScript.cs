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

    public void InstantiatePopUp()
    {
        Vector3 patientPos = transform.position;
        //transform.position = new Vector3(patientPos.x, patientPos.y + 1.5f, patientPos.z);
        instantiatedPopUp = Instantiate(myPopUp);
        instantiatedPopUp.transform.position = new Vector3(patientPos.x, patientPos.y + 1.5f, patientPos.z);
    }

    public void DestroyPopUp()
    {
        Destroy(instantiatedPopUp);
        //DestroyImmediate(obj, true);
    }
    //maybe we use an independet script for the random time (Patrick)
    public float GetRandomTime()
     {
        randomTime = Random.Range(minTimeTillTask, maxTimeTillTask);
        return randomTime;
     }



}
