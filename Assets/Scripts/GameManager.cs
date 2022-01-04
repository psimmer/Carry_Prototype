using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PopUpPrefab;
    [SerializeField] private GameObject LevelUI;
    //All Patients Objects we have in the Prototyp
    [SerializeField] private GameObject patientObject01;
    [SerializeField] private GameObject patientObject02;
    [SerializeField] private GameObject patientObject03;
    [SerializeField] private GameObject patientObject04;
    [SerializeField] private playerScript player;
    private GameObject popUp;
    //All Patients we have in the Prototyp
    private PatientScript patient01 = new PatientScript(100, "Patient01", ItemType.Bandage);
    private PatientScript patient02 = new PatientScript(90, "Patient02", ItemType.Bandage);
    private PatientScript patient03 = new PatientScript(70, "Patient03", ItemType.Bandage);
    private PatientScript patient04 = new PatientScript(70, "Patient04", ItemType.Bandage);
    //von hier
    [SerializeField]private PopUpBandages popUpBandages;
    //bis hier
    private bool timer = false;
    // 2 Lists of the Objects and the reference
    private List<GameObject> patObjects = new List<GameObject>(4);
    private List<PatientScript> patients = new List<PatientScript>(4);
    private List<PatientScript> illPatients = new List<PatientScript>();
    private List<GameObject> popUps = new List<GameObject>();
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

        // Stoping Menu Music.
        Destroy(GameObject.FindGameObjectWithTag("MenuMusic"));
    }

    void Update()
    {
        RandomPopUp();
        escPause();
        DestroyPopUp();
    }
    // Instantiate randomly a pop Up at a random patient
    public void RandomPopUp()
    {
        int randomIndex = Random.Range(0, patients.Count);
        PatientScript randomPatient = patients[randomIndex]; // in liste
        illPatients.Add(randomPatient);
        if (randomPatient.needSomething == false)
        {
            StartCoroutine("InstantiatePopUp");
            if (timer)
            {
                timer = false;
                randomPatient.needSomething = true;
                Vector3 objectPos = patObjects[randomIndex].transform.position;
                PopUpPrefab.transform.position = new Vector3(objectPos.x, objectPos.y + 1.5f, objectPos.z);
                popUp = Instantiate(PopUpPrefab, LevelUI.transform);
                popUps.Add(popUp);
                Debug.Log("Hello " + randomPatient.Name);
            }


        }
    }

    public void DestroyPopUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.popUpBool)
        {
            popUpBandages.DestroyMe(popUps[popUps.Count - 1]); 
        }
    }


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
