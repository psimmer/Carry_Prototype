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
            Debug.Log("true");
        }
    }
    // We lose the connectivity to the item which we was triggering and set itemholder to null
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            collidesWithPatient = false;
            Debug.Log("false");
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
                case Task.Wound:    // For a wound you need Bandage.
                    {                         
                        if(inventory.itemHolder.item.itemType == ItemType.Bandage)
                        {
                            Treatment(other.gameObject);
                        }                      
                        break;                
                    }
                case Task.Pain:     //For Pain you need Pill.
                    {
                        if (inventory.itemHolder.item.itemType == ItemType.Pill)
                        {
                            Treatment(other.gameObject);
                        }
                        break;
                    }

            }
        }
    }

    public void Treatment(GameObject patient)
    {                                                            
        if (Input.GetKey(KeyCode.Space) && collidesWithPatient)
        {                                                       
            patient.GetComponent<PatientScript>().DestroyPopUp();
            patient.GetComponent<PatientScript>().needSomething = false;
            inventory.itemHolder.item = null;
        }
    }

    // If we end the Application the itemholder set to null
    private void OnApplicationQuit()
    {
        inventory.itemHolder = null;
    }
}
