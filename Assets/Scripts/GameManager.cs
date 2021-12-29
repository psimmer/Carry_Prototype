using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PopUpPrefab;
    //All Patients Objects we have in the Prototyp
    [SerializeField] private GameObject patientObject01;
    [SerializeField] private GameObject patientObject02;
    [SerializeField] private GameObject patientObject03;
    [SerializeField] private GameObject patientObject04;

    //All Patients we have in the Prototyp
    private PatientScript patient01 = new PatientScript(100, "Patient01");
    private PatientScript patient02 = new PatientScript(90, "Patient02");
    private PatientScript patient03 = new PatientScript(70, "Patient03");
    private PatientScript patient04 = new PatientScript(70, "Patient04");

    private bool timer = false;
    // 2 Lists of the Objects and the reference
    private List<GameObject> patObjects = new List<GameObject>(4);
    private List<PatientScript> patients = new List<PatientScript>(4);
    void Start()
    {
        // Adding in Lists
        patients.Add(patient01);
        patients.Add(patient02);
        patients.Add(patient03);
        patients.Add(patient04);
        patObjects.Add(patientObject01);
        patObjects.Add(patientObject02);
        patObjects.Add(patientObject03);
        patObjects.Add(patientObject04);
        
    }

    void Update()
    {
        RandomPopUp();

        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0f;
                SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            }
        }
    }
    // Instantiate randomly a pop Up at a random patient
    public void RandomPopUp()
    {
        int randomIndex = Random.Range(0, patients.Count);
        PatientScript randomPatient = patients[randomIndex];
        if (randomPatient.needSomething == false)
        {
            StartCoroutine("InstantiatePopUp");
            if (timer)
            {
                timer = false;
                randomPatient.needSomething = true;
                Vector3 objectPos = patObjects[randomIndex].transform.position;
                PopUpPrefab.transform.position = new Vector3(objectPos.x, objectPos.y + 1.5f, objectPos.z);
                Instantiate(PopUpPrefab);
                Debug.Log("Hello " + randomPatient.Name);
            }


        }
    }
    IEnumerator InstantiatePopUp()
    {
        yield return new WaitForSeconds(patient01.GetRandomTime());
        timer = true;
        StopCoroutine("InstantiatePopUp");
    }

   



}
