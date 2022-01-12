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
    [SerializeField] private GameObject healingParticles;
    [SerializeField] private GameObject damageParticles;
    [SerializeField] private GameObject deathParticles;
    [SerializeField] private int timeOutDamage = 1;
    [SerializeField] private int timeOutPunishment = 5;
    //[SerializeField] private int patientDeathPunishment = 20;
    public InventoryObject inventory;
    private PatientScript patient;
    private playerScript player;
    public float CurrentFillAmount { get; private set; }

    private void Awake()
    {
        CurrentFillAmount = 1;
    }
    private void Update()
    {
        LerpToZero();
        TimeOut();

    }

    //public void RadialBar()
    //{
    //    //player = FindObjectOfType<playerScript>();
    //    //patient = gameObject.transform.parent.parent.GetComponent<PatientScript>();
    //    //Debug.Log(patient);
    //    //if (Input.GetKeyUp(KeyCode.Space) && player.collidesWithPatient)
    //    //{
    //    //    PatientDamage(patient);
    //    //}
    //    //if (Input.GetKey(KeyCode.Space) && player.collidesWithPatient)
    //    //{
    //    //    LerpToHeal();
    //    //    if(radialBarImg.fillAmount >= 1)
    //    //    {
    //    //        PatientHealing();
    //    //        patient.DestroyPopUp();
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    LerpToZero();
    //    //}
    //}

    //public void LerpToHeal()
    //{
    //        radialBarImg.fillAmount = Mathf.Lerp(radialBarImg.fillAmount, maxValue, interpolationPoint);
    //        interpolationPoint += Time.deltaTime * speed;
    //}
    public void LerpToZero()
    {
            radialBarImg.fillAmount = Mathf.Lerp(maxValue, minValue, interpolationPoint);
            interpolationPoint += Time.deltaTime * speed;
            CurrentFillAmount = radialBarImg.fillAmount;
    }
    public void TimeOut()
    {
        if (CurrentFillAmount <= 0)
        {
            PatientDamage();

            if (patient.CurrentHP <= 0)
            {
                PatientDeath();
            }
        }
    }

    public void PatientDamage()
    {
        player = FindObjectOfType<playerScript>();
        patient = gameObject.transform.parent.parent.GetComponent<PatientScript>();
        patient.CurrentHP -= timeOutDamage;
        patient.SpawnParticles(damageParticles, 3);
        player.CurrentStressLvl += timeOutPunishment;
        patient.DestroyPopUp();
    }
    //public void PatientHealing()
    //{
    //    player = FindObjectOfType<playerScript>();
    //    patient = gameObject.transform.parent.parent.GetComponent<PatientScript>();
    //    patient.CurrentHP += timeOutDamage;
    //    patient.SpawnParticles(healingParticles, 3);
    //    player.CurrentStressLvl -= timeOutPunishment;
    //    patient.DestroyPopUp();
    //}
    public void PatientDeath()
    {
        this.patient.SpawnParticles(deathParticles, 3);
        player.CurrentStressLvl += 10;
        FindObjectOfType<GameManager>().removePatientFromList(patient);
        patient.DestroyHealthBar();
        Destroy(patient.gameObject, 3);
    }

}
