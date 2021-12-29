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

        firstButton.Select();
    }
    public void LeavOptionsMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
