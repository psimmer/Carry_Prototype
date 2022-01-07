using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientHealthBar : MonoBehaviour
{
    private Slider slider;
    private PatientScript patient;
    private List<PatientScript> patientList;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
