using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    /// <summary>
    /// Game will be started
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    /// <summary>
    /// Exit to Desktop
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsMenu"); 
    }
}
