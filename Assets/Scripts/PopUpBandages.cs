using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBandages : MonoBehaviour
{
    public void DestroyMe(GameObject obj)
    {
        //Destroy(obj);
        DestroyImmediate(obj, true);
    }
}
