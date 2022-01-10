using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static GlobalData instance;

    public float currentStresslvl;
    public int currentItem;
    public Vector3 currentPlayerPosition;
    public bool isSaveFileLoaded = false;
    public float timeLeft;
    
    

    private void Awake()
    {
        if (instance == null)       //Singleton
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);  //take GlobalData to the next scene
    }
}
