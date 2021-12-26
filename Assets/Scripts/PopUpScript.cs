using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    [SerializeField] private BandageScript bandageScript;
    [SerializeField] private PatientScript patient;

    //boolean goes to PatientScript
    private static bool popUpBool = false;
    public bool PopUpBool
    {
        get {return popUpBool; }
        set { popUpBool = value; }
    }
    void Update()
    {
        DestroyPopUp();
    }

    //Destroyes the PopUp and reset all booleans to false
    public void DestroyPopUp()
    {
        if (Input.GetKey(KeyCode.Space) && this.bandageScript.ItemBool && this.patient.RecoverBool)
        {
            PopUpBool = false;
            bandageScript.ItemBool = false;
            patient.RecoverBool = false;
            Destroy(this.gameObject);
        }
    }


}
