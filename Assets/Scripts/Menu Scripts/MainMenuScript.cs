using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] Button firstButton;

    private void Awake()
    {

        if (firstButton != null)
        {
            firstButton.Select();
        }
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

    public void LoadSaveFile()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            //Debug.Log("currentStresslvl: " + data.currentStressLvl);

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
