using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] Button firstButton;
    [SerializeField] Button loadButton;

    private void Awake()
    {

        if (firstButton != null)
        {
            firstButton.Select();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Scene");
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsMenu"); 
    }

    public void LoadSaveFile()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            GlobalData.instance.isSaveFileLoaded = true;

            GlobalData.instance.currentStresslvl = data.currentStressLvl;
            GlobalData.instance.currentItem = data.currentItem;

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];

            GlobalData.instance.currentPlayerPosition = position;
            SceneManager.LoadScene("Main Scene");
        }
        else
        {
            SceneManager.LoadScene("Main Scene");
        }
    }
}
