using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlFinishScript : MonoBehaviour
{

    [SerializeField]
    Button firstButton;

    private void Awake()
    {

        firstButton.Select();
    }
    public void LeaveFinishMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
