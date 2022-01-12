using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private UIManager UIManager;

    private void Start()
    {
        //set the correct time when a save file is loaded
        if (GlobalData.instance.isSaveFileLoaded && GlobalData.instance != null)
        {
            UIManager.TimeLeft = GlobalData.instance.timeLeft;
        }
    }

    void Update()
    {
        
        // Countdown every second until 0 is reached.
        if (UIManager.TimeLeft >= 0)
        {
            if ((int)UIManager.TimeLeft % 60 < 10)
            {
                timerText.text = (int)UIManager.TimeLeft / 60 + ":0" + (int)UIManager.TimeLeft % 60;
            }
            else
            {
                timerText.text = (int)UIManager.TimeLeft / 60 + ":" + (int)UIManager.TimeLeft % 60;
            }

            UIManager.TimeLeft -= Time.deltaTime;
            if (GlobalData.instance != null)
            {
                GlobalData.instance.timeLeft = UIManager.TimeLeft;
            }
        }
        else
        {
            SceneManager.LoadScene("LvlFinishMenu");
        }
    }
}