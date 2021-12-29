using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField]
    Button firstButton;

    private void Awake()
    {

        firstButton.Select();
    }

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
