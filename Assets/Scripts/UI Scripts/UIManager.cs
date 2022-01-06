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
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0f;
            FindObjectOfType<AudioSource>().GetComponent<AudioSource>().Pause();
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadSceneAsync("PauseMenu");
            Time.timeScale = 1f;
            FindObjectOfType<AudioSource>().GetComponent<AudioSource>().Play();
        }
    }
}
