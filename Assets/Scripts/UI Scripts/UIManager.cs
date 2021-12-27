using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private float timeLeft;

    public float TimeLeft
    {
        get { return timeLeft; }
        set { timeLeft = value; }
    }


    public void Pause()
    {
        Debug.Log("This button is useless yet. I just placed it in the UI to prepare it for Patrick :) This function is in the UIManager Script.");
    }
}
