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
    }

    public void TimeOut()
    {
        PatientScript patient = GetComponent<PatientScript>();

        if (CurrentFillAmount <= 0)
        {
            patient.CurrentHP -= 2;
            Destroy(this.gameObject);
        }
        //else if(patient.CurrentHP <= 0)
        //{
        //    Destroy(patient);
        //}
    }


}
