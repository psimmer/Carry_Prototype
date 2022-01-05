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
    [SerializeField] private GameObject bandagePopUp;
    [SerializeField] private GameObject pillPopUp;
    [SerializeField] private float minTimeTillTask;
    [SerializeField] private float maxTimeTillTask;
    [SerializeField] private GameObject instantiatedPopUp;
    [SerializeField] public Task currentTask;

    //public float PatientHealth { get; set; } <-- need later
    public bool needSomething { get; set; }
    public float randomTime { get; set; }


    private void Start()
    {
        needSomething = false;
        instantiatedPopUp = null;
    }

    public void InstantiatePopUp(Task currentTask)
    {
        Vector3 patientPos = transform.position;
        switch (currentTask)
        {
            case Task.Wound:
                {
                    instantiatedPopUp = Instantiate(bandagePopUp);
                    break;
                }
            case Task.Pain:
                {
                    instantiatedPopUp = Instantiate(pillPopUp);
                    break;
                }
        }
        instantiatedPopUp.transform.position = new Vector3(patientPos.x, patientPos.y + 1.5f, patientPos.z);
    }

    public void DestroyPopUp()
    {
        Destroy(instantiatedPopUp);
    }

    public float GetRandomTime()
     {
        randomTime = Random.Range(minTimeTillTask, maxTimeTillTask);
        return randomTime;
     }



}
