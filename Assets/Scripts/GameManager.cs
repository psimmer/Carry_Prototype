using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PopUpPrefab;
    [SerializeField] private GameObject LevelUI;
    //All Patients Objects we have in the Prototyp
    //[SerializeField] private GameObject patientObject01;
    //[SerializeField] private GameObject patientObject02;
    //[SerializeField] private GameObject patientObject03;
    //[SerializeField] private GameObject patientObject04;
    [SerializeField] private playerScript player;
    private GameObject popUp;
    //All Patients we have in the Prototyp
    [SerializeField]
    private PatientScript patient01;
    [SerializeField]
    private PatientScript patient02;
    [SerializeField]
    private PatientScript patient03;
    [SerializeField]
    private PatientScript patient04; 
    //von hier
    [SerializeField]private PopUp currentPopUp;
    //bis hier
    private bool timer = false;
    // 2 Lists of the Objects and the reference
    //private List<GameObject> patObjects = new List<GameObject>(4);
    private List<PatientScript> patients = new List<PatientScript>();
    private List<PatientScript> illPatients = new List<PatientScript>();
    //private List<GameObject> popUps = new List<GameObject>();

    void Start()
    {
        // Adding in Lists
        
        patients.Add(patient01);
        patients.Add(patient02);
        patients.Add(patient03);
        patients.Add(patient04);
        
        //patObjects.Add(patientObject01);
        //patObjects.Add(patientObject02);
        //patObjects.Add(patientObject03);
        //patObjects.Add(patientObject04);

        // Stoping Menu Music.
        Destroy(GameObject.FindGameObjectWithTag("MenuMusic"));
    }

    void Update()
    {
        RandomPopUp();
        escPause();
        
    }
    // Instantiate randomly a pop Up at a random patient
    public void RandomPopUp()
    {
        int randomIndex = Random.Range(0, patients.Count);
        PatientScript randomPatient = patients[randomIndex]; // in liste
        //illPatients.Add(randomPatient);
        
        if (randomPatient.needSomething == false)
        {
            StartCoroutine("InstantiatePopUp");
            if (timer)
            {
                timer = false;
                randomPatient.needSomething = true;
                randomPatient.InstantiatePopUp();
                //Vector3 objectPos = patients[randomIndex].transform.position;
                //randomPatient.MyPopUp.transform.position = new Vector3(objectPos.x, objectPos.y + 1.5f, objectPos.z);
                //randomPatient.InstantiatedPopUp = Instantiate(randomPatient.MyPopUp, LevelUI.transform);
                Debug.Log("Hello " + randomPatient.Name);
            }
        }
        else
        {
            //Debug.Log("instantiated ist nicht null");
        }
    }

    //public void Treatment()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && player.popUpBool)
    //    {
    //        GetComponent<PatientScript>().DestroyPopUp();
    //    }
    //}


    //using the esc button to open the pause menu
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
        }
    }

    IEnumerator InstantiatePopUp()
    {
        yield return new WaitForSeconds(patient01.GetRandomTime());
        timer = true;
        StopCoroutine("InstantiatePopUp");
    }

   



}
