using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    //All Patients we have in the Prototyp
    [SerializeField] private PatientScript patient01;
    [SerializeField] private PatientScript patient02;
    [SerializeField] private PatientScript patient03;
    [SerializeField] private PatientScript patient04;
    [SerializeField] private playerScript player;

    private bool IsTimerOn = false;
    private List<PatientScript> patients = new List<PatientScript>();

    void Start()
    {
        //if (File.Exists(Application.persistentDataPath + "/player.carry"))
        //{
        //    player.transform.position = GlobalData.instance.currentPlayerPosition;
        //    player.CurrentStressLvl = GlobalData.instance.currentStresslvl;
        //    //player.inventory.itemHolder.item.ItemType = (ItemType)GlobalData.instance.currentItem;

        //}
        patients.Add(patient01);
        patients.Add(patient02);
        patients.Add(patient03);
        patients.Add(patient04);
        Destroy(GameObject.FindGameObjectWithTag("MenuMusic"));
    }

    void Update()
    {
        RandomPopUp();
        //escPause();
        player.isStressLvlMax();
    }
    /// <summary>
    /// Spawns a pop up at a random patient
    /// </summary>
    public void RandomPopUp()
    {
        if (patients.Count > 0)
        {
            int randomIndex = Random.Range(0, patients.Count);
            PatientScript randomPatient = patients[randomIndex];

            if (randomPatient.needSomething == false)
            {
                StartCoroutine("InstantiatePopUp");
                if (IsTimerOn)
                {
                    IsTimerOn = false;
                    randomPatient.needSomething = true;
                    randomPatient.currentTask = (Task)Random.Range(0, 2);
                    randomPatient.InstantiatePopUp(randomPatient.currentTask);
                }
            }
        }
    }
    
    IEnumerator InstantiatePopUp()
    {
        yield return new WaitForSeconds(patient01.GetRandomTime());
        IsTimerOn = true;
        StopCoroutine("InstantiatePopUp");
    }

    public void removePatientFromList(PatientScript patient)
    {
        patients.Remove(patient);
    }

   

}
