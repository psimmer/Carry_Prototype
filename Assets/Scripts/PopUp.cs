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
    [SerializeField] private GameObject damageParticles;
    [SerializeField] private GameObject deathParticles;
    [SerializeField] private int timeOutDamagePatient = 1;
    [SerializeField] private int timeOutStresslvlPlayer = 5;
    
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
        patient.CurrentHP -= timeOutDamagePatient;
        patient.SpawnParticles(damageParticles, 3);
        player.CurrentStressLvl += timeOutStresslvlPlayer;
        patient.DestroyPopUp();
    }
  
    public void PatientDeath()
    {
        this.patient.SpawnParticles(deathParticles, 3);
        player.CurrentStressLvl += 10;
        FindObjectOfType<GameManager>().removePatientFromList(patient);
        patient.DestroyHealthBar();
        Destroy(patient.gameObject, 3);
    }

}
