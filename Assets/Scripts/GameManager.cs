using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //All Patients we have in the Prototyp
    [SerializeField] private PatientScript patient01;
    [SerializeField] private PatientScript patient02;
    [SerializeField] private PatientScript patient03;
    [SerializeField] private PatientScript patient04;

    private bool IsTimerOn = false;
    private List<PatientScript> patients = new List<PatientScript>();

    void Start()
    {
        patients.Add(patient01);
        patients.Add(patient02);
        patients.Add(patient03);
        patients.Add(patient04);
        Destroy(GameObject.FindGameObjectWithTag("MenuMusic"));
    }

    void Update()
    {
        RandomPopUp();
        escPause();
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

    /// <summary>
    /// using the esc button to open the pause menu
    /// </summary>
    public void escPause()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0f;
                FindObjectOfType<AudioSource>().GetComponent<AudioSource>().Pause();
                SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.UnloadSceneAsync("PauseMenu");
                Time.timeScale = 1f;
                FindObjectOfType<AudioSource>().GetComponent<AudioSource>().Play();
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
