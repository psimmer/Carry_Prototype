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
    [SerializeField] private int patientDeathPunishment = 20;
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
        RadialBar();
    }

    public void RadialBar()
    {
        player = FindObjectOfType<playerScript>();
        patient = gameObject.transform.parent.parent.GetComponent<PatientScript>();

        if (Input.GetKeyUp(KeyCode.Space) && player.collidesWithPatient)
        {
            PatientDamage();
        }
        if (Input.GetKey(KeyCode.Space) && player.collidesWithPatient)
        {
            radialBarImg.fillAmount = Mathf.Lerp(CurrentFillAmount, maxValue, interpolationPoint);
            interpolationPoint += Time.deltaTime * speed;
            if(radialBarImg.fillAmount >= 1)
            {
                PatientHealing();
                inventory.itemHolder.item = null;
                patient.DestroyPopUp();
            }
        }
        else
        {
            radialBarImg.fillAmount = Mathf.Lerp(maxValue, minValue, interpolationPoint);
            interpolationPoint += Time.deltaTime * speed;
            CurrentFillAmount = radialBarImg.fillAmount;
            TimeOut();
        }
    }

    public void TimeOut()
    {
        if (CurrentFillAmount <= 0)
        {
            PatientDamage();

            if (patient.CurrentHP <= 0)
            {
                patient.SpawnParticles(deathParticles, 3);
                player.CurrentStressLvl += patientDeathPunishment;
                FindObjectOfType<GameManager>().removePatientFromList(patient);
                patient.DestroyHealthBar();
                Destroy(patient.gameObject, 3);
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
    public void PatientHealing()
    {
        player = FindObjectOfType<playerScript>();
        patient = gameObject.transform.parent.parent.GetComponent<PatientScript>();
        patient.CurrentHP += timeOutDamage;
        patient.SpawnParticles(healingParticles, 3);
        player.CurrentStressLvl -= timeOutPunishment;
        patient.DestroyPopUp();
    }

}
