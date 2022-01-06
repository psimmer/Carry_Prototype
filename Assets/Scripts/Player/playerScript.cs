using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public InventoryObject inventory;
    public bool collidesWithPatient { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        // popUpBool checks if the player triggers with the patient
        if (other.gameObject.CompareTag("Patient"))
        {
            collidesWithPatient = true;
            //Debug.Log("true");
        }
    }
    // We lose the connectivity to the item which we was triggering and set itemholder to null
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            collidesWithPatient = false;
            //Debug.Log("false");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Getting the itemType about the Component of the item what we are triggering,
        //and adding the item in our InventorySlot in the InventoryObject.cs
        Item item = other.GetComponent<Item>();

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
                            Treatment(other.gameObject, inventory.itemHolder.item);
                        }                      
                        break;                
                    }
                case Task.Pill:
                    {
                        if (inventory.itemHolder.item.itemType == ItemType.Pill)
                        {
                            Treatment(other.gameObject, inventory.itemHolder.item);
                        }
                        break;
                    }

            }
        }
    }

    public void Treatment(GameObject obj, ItemObject currentItem)
    {
        PatientScript patient = obj.GetComponent<PatientScript>();
        if (Input.GetKey(KeyCode.Space) && collidesWithPatient)
        {                                                       
            patient.DestroyPopUp();
            if (patient.needSomething)
            {
                inventory.itemHolder.item = null;
                
                patient.CurrentHP += 1;     //modify hard code
                if (patient.PatientMaxHp > patient.CurrentHP) // patient health + restore health > patientHealth = patient is recovered
                {
                    Debug.Log($"Current hp: {patient.CurrentHP}");
                }
                else if (patient.CurrentHP >= patient.PatientMaxHp)
                {
                    FindObjectOfType<GameManager>().removePatientFromList(patient);
                    Destroy(obj);
                    Debug.Log($"Patient max hp: {patient.PatientMaxHp}");
                    Debug.Log($"Patient Current HP: {patient.CurrentHP}");
                    Debug.Log("Patient is healed");
                }
                patient.needSomething = false;
            }
        }
    }

    // If we end the Application the itemholder set to null
    private void OnApplicationQuit()
    {
        inventory.itemHolder = null;
    }
}
