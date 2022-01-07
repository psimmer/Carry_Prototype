using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private float timeLeft;
    [SerializeField] Button firstButton;
    [SerializeField] private TMP_Text pauseText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button saveAndQuitButton;    
    [SerializeField] private Button quitToMainMenuButton;
    [SerializeField] private Button optionsButton;        
    [SerializeField] private Button exitGameButton;

    public float TimeLeft
    {
        get { return timeLeft; }
        set { timeLeft = value; }
    }

    private void Awake()
    {
        //all pause UI elements are set false
        if (firstButton != null)
        {
            firstButton.Select();
        }

        pauseText.GetComponent<Transform>().gameObject.SetActive(false);
        continueButton.GetComponent<Transform>().gameObject.SetActive(false);
        saveAndQuitButton.GetComponent<Transform>().gameObject.SetActive(false);
        quitToMainMenuButton.GetComponent<Transform>().gameObject.SetActive(false);
        optionsButton.GetComponent<Transform>().gameObject.SetActive(false);
        exitGameButton.GetComponent<Transform>().gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GamePaused();
        }
    }

    /// <summary>
    /// pauses the game and sets the Pause UI active
    /// </summary>
    public void GamePaused()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0f;
            pauseText.GetComponent<Transform>().gameObject.SetActive(true);
            continueButton.GetComponent<Transform>().gameObject.SetActive(true);
            saveAndQuitButton.GetComponent<Transform>().gameObject.SetActive(true);
            quitToMainMenuButton.GetComponent<Transform>().gameObject.SetActive(true);
            optionsButton.GetComponent<Transform>().gameObject.SetActive(true);
            exitGameButton.GetComponent<Transform>().gameObject.SetActive(true);
            FindObjectOfType<AudioSource>().GetComponent<AudioSource>().Pause();
        }
        else
        {
            pauseText.GetComponent<Transform>().gameObject.SetActive(false);
            continueButton.GetComponent<Transform>().gameObject.SetActive(false);
            saveAndQuitButton.GetComponent<Transform>().gameObject.SetActive(false);
            quitToMainMenuButton.GetComponent<Transform>().gameObject.SetActive(false);
            optionsButton.GetComponent<Transform>().gameObject.SetActive(false);
            exitGameButton.GetComponent<Transform>().gameObject.SetActive(false);
            Time.timeScale = 1f;
            FindObjectOfType<AudioSource>().GetComponent<AudioSource>().Play();
        }
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
