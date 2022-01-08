using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    // Particles:
    [SerializeField] private GameObject healingParticles;
    [SerializeField] private GameObject fullHealingParticles;
    [SerializeField] private float particlesDuration;

    //[SerializeField] private StressLevelScript stressLvlBar;
    [SerializeField] private float currentStressLvl;
    [SerializeField] private float maxStressLvl;

    [Tooltip("This value multiplies the stress")]
    [Range(1, 4)]
    [SerializeField] private float stressMultiplier;


    [Tooltip("This value reduce the stress")]
    [Range(0, 1)]
    [SerializeField] private float stressReductionMultiplier;

    public InventoryObject inventory;
    public bool collidesWithPatient { get; set; }
    public float MaxStressLvl
    {
        get { return maxStressLvl; }
    }

    public float CurrentStressLvl
    {
        get { return currentStressLvl; }
        set 
        { 
            if (value > 0) // maybe we need to check the upper limit too of the stress Level.
            {
                currentStressLvl = value; 
            }
            else
            {
                currentStressLvl = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // popUpBool checks if the player triggers with the patient
        if (other.gameObject.CompareTag("Patient"))
        {
            collidesWithPatient = true;
        }
    }
    // We lose the connectivity to the item which we was triggering and set itemholder to null
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            collidesWithPatient = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Getting the itemType about the Component of the item what we are triggering,
        //and adding the item in our InventorySlot in the InventoryObject.cs
        Item item = other.GetComponent<Item>();
        PatientScript patient = other.GetComponent<PatientScript>();

        if (Input.GetKey(KeyCode.Space) && item)
        {
            inventory.AddItem(item.item);
        }

        if (other.gameObject.CompareTag("Patient") && inventory.itemHolder.item != null)
        {
            switch (other.GetComponent<PatientScript>().currentTask)
            {
                case Task.Bandage:
                    {                         
                        if(inventory.itemHolder.item.ItemType == ItemType.Bandage)
                        {
                            CorrectTreatment(other.gameObject, inventory.itemHolder.item);
                        }
                        else
                        {
                            WrongTreatment(other.gameObject, inventory.itemHolder.item);
                        }
                        break;                
                    }
                case Task.Pill:
                    {
                        if (inventory.itemHolder.item.ItemType == ItemType.Pill)
                        {
                            CorrectTreatment(other.gameObject, inventory.itemHolder.item);
                        }
                        else
                        {
                            WrongTreatment(other.gameObject, inventory.itemHolder.item);
                        }
                        break;
                    }
            }
        }
    }

    /// <summary>
    /// Patient loses health, stresslvl of player rises
    /// </summary>
    /// <param name="obj">Patient</param>
    /// <param name="currentItem">currentItem</param>
    public void WrongTreatment(GameObject obj, ItemObject currentItem) 
    {
        PatientScript patient = obj.GetComponent<PatientScript>();

        if (Input.GetKey(KeyCode.Space) && collidesWithPatient)
        {
            inventory.itemHolder.item = null;
            patient.CurrentHP -= currentItem.RestoreHealth;
            this.currentStressLvl += currentItem.RestoreHealth * stressMultiplier;
            if(patient.CurrentHP <= 0)
            {
                FindObjectOfType<GameManager>().removePatientFromList(patient);
                patient.DestroyHealthBar();
                patient.DestroyPopUp();
                Destroy(obj);
            }
        }
    }

    /// <summary>
    /// Patient gains health, stresslvl of player decreases
    /// </summary>
    /// <param name="obj">Patient</param>
    /// <param name="currentItem">currentItem</param>
    public void CorrectTreatment(GameObject obj, ItemObject currentItem)
    {
        PatientScript patient = obj.GetComponent<PatientScript>();
        if (Input.GetKey(KeyCode.Space) && collidesWithPatient && patient.needSomething)
        {
            patient.SpawnParticles(healingParticles, particlesDuration);
            patient.DestroyPopUp();
            inventory.itemHolder.item = null;
            patient.CurrentHP += currentItem.RestoreHealth;
            this.CurrentStressLvl -= currentItem.RestoreHealth * stressReductionMultiplier;
            if (patient.CurrentHP >= patient.PatientMaxHp)
            {
                patient.SpawnParticles(fullHealingParticles, particlesDuration);
                FindObjectOfType<GameManager>().removePatientFromList(patient);
                patient.DestroyHealthBar();
                Destroy(obj, 3);
            }
            
        }
    }

    /// <summary>
    /// If Stresslvl is Max, GameOver scene will be loaded
    /// </summary>
    public void isStressLvlMax()        
    {
        if (this.currentStressLvl >= this.maxStressLvl)
        {
            //TODO: reset all stats
            SceneManager.LoadScene("GameOver");
        }
    }

    /// <summary>
    ///  If we end the Application the itemholder set to null
    /// </summary>
    private void OnApplicationQuit()
    {
        inventory.itemHolder = null;
    }
}
