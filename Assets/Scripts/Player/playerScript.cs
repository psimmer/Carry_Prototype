using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    //[SerializeField] private StressLevelScript stressLvlBar;
    [SerializeField] private float currentStressLvl;
    [SerializeField] private float maxStressLvl;

    public InventoryObject inventory;
    public bool collidesWithPatient { get; set; }

    private void Start()
    {
        maxStressLvl = 10f;
        //stressLvlBar.GetComponent<Slider>().value = 0f;
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
                        if(inventory.itemHolder.item.itemType == ItemType.Bandage)
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
                        if (inventory.itemHolder.item.itemType == ItemType.Pill)
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
            patient.CurrentHP--;        //!!!!!modify hard code!!!!!!
            this.currentStressLvl+=3;    //!!!!!modify hard code!!!!!!
            
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
        if (Input.GetKey(KeyCode.Space) && collidesWithPatient)
        {                                                       
            patient.DestroyPopUp();

            if (patient.needSomething)
            {
                inventory.itemHolder.item = null;
                
                patient.CurrentHP++;     //!!!!!!modify hard code!!!!!!
                this.currentStressLvl--;    //!!!!!modify hard code!!!!!!

                if (patient.CurrentHP >= patient.PatientMaxHp)
                {
                    FindObjectOfType<GameManager>().removePatientFromList(patient);
                    Destroy(obj);
                }
                patient.needSomething = false;
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
            SceneManager.LoadScene("MainMenu");
            //TODO: Load GameOver Scene
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
