using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    Button firstButton;

    private void Awake()
    {

        firstButton.Select();
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void LeaveGameOverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
