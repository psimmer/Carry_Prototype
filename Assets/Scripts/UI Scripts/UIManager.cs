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


    /// <summary>
    /// pauses the game and time and loads additive the PauseScene
    /// </summary>
    public void GamePaused()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }
}
