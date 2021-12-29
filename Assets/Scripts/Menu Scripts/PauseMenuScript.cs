using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public static PauseMenuScript instance;

    private void Awake()
    {
        //Singleton, so only one Pause scene exists --> doesnt work yet
        if (instance == null){       
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);  
    }

    public void ContinueGame()
    {
        
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1f;
    }

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
