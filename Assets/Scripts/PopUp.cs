using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public enum PopUps
    {
        Bandages,
        Pills
    }

    public void DestroyMe(GameObject obj)
    {
        //Destroy(obj);
        DestroyImmediate(obj, true);
    }
}
