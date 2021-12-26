using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientScript : MonoBehaviour
{
    [SerializeField] private PopUpScript popUp;        
    [SerializeField] private GameObject popUpPrefab;    
    [SerializeField] private int minTimeTillTask = 1;
    [SerializeField] private int maxTimeTillTask = 5;

    // This boolean goes to PopUpScript
    private static bool recoverBool;
    public bool RecoverBool
    {
        get { return recoverBool; }
        set { recoverBool = value; }
    }

    private void Start()
    {
        recoverBool = false;
    }
    

    void Update()
    {

        if (!popUp.PopUpBool)
        {
            StartCoroutine("TaskPopping");
        }
    }

    //Random number of waiting Time till Task Pops Up
    public float RandomPopUpRange()
    {
        return Random.Range(minTimeTillTask, maxTimeTillTask);
    }

    //Coroutine where and when the Pop up Instantiate
    IEnumerator TaskPopping()
    {
        yield return new WaitForSeconds(RandomPopUpRange());
        popUpPrefab.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        Instantiate(popUpPrefab);
        popUp.PopUpBool = true;
        StopCoroutine("TaskPopping");

    }


    // Controll if the nurse triggers with the Patient
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            recoverBool = true;
        }
    }
    // Controll if the nurse doesnt triggers with the Patient
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            recoverBool = false;
        }
    }



}
