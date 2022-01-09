using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    private float maxValue = 1f;
    private float minValue = 0f;
    [SerializeField] private float interpolationPoint = 0f;
    [SerializeField] private Image radialBarImg;
    [SerializeField] private float speed;
    [SerializeField] private PatientScript patient;
    public float CurrentFillAmount { get; private set; }

    private void Awake()
    {
        CurrentFillAmount = 1;
    }
    private void Update()
    {
        RadialBar();
    }

    public void RadialBar()
    {
        radialBarImg.fillAmount = Mathf.Lerp(maxValue, minValue, interpolationPoint);
        interpolationPoint += Time.deltaTime * speed;
        CurrentFillAmount = radialBarImg.fillAmount;
        TimeOut();
    }

    public void TimeOut()
    {
        if (CurrentFillAmount <= 0)
        {
            patient = gameObject.transform.parent.parent.GetComponent<PatientScript>();
            patient.CurrentHP -= 5;
            patient.DestroyPopUp();
        }

        //else if(patient.CurrentHP <= 0)
        //{
        //    Destroy(patient);
        //}
    }


}
