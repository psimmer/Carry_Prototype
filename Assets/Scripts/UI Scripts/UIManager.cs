using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private float timeLeft;

    public float TimeLeft
    {
        get { return timeLeft; }
        set { timeLeft = value; }
    }


    public void GamePaused()
    {
        //Time.timeScale = 0f;
        //SceneManager.LoadScene("PauseMenu");
    }
}
