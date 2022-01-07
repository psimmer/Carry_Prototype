using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    [SerializeField]
    Button firstButton;

    private void Awake()
    {

        if (firstButton != null)
        {
            firstButton.Select();
        }
    }
    public void LeavOptionsMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
