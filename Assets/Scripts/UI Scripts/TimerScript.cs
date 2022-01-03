using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private UIManager UIManager;

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
        }
        else
        {
            SceneManager.LoadScene("LvlFinishMenu");
        }
    }

    // Timer starts at '5:59' although timerText.text gets displayed before UIManager.timeLeft gets counted down. :thinking_Emoji: xD
    // However, some other games "skip" the first second, too.
}