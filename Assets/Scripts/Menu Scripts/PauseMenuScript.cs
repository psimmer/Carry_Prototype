using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

    [SerializeField]
    Button firstButton;

    private void Awake()
    {

        firstButton.Select();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ContinueGame();
        }
    }

    public void ContinueGame()
    {
        
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1f;
        FindObjectOfType<AudioSource>().GetComponent<AudioSource>().Play();
    }

    //Doesnt work the way i want, so for now the options buttion in the pause menu is disabled
    //public void OptionsMenu()
    //{
    //    SceneManager.LoadScene("OptionsMenu");
    //}


    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
   
}
