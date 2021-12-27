using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private float timeInSeconds;

    void Update()
    {
        // Countdown every second until 0 is reached.
        if (timeInSeconds >= 0)
        {
            if ((int)timeInSeconds % 60 < 10)
            {
                timerText.text = (int)timeInSeconds / 60 + ":0" + (int)timeInSeconds % 60;
            }
            else
            {
                timerText.text = (int)timeInSeconds / 60 + ":" + (int)timeInSeconds % 60;
            }

            timeInSeconds -= 1 * Time.deltaTime;
        }
    }

    // Timer starts at '5:59' although timerText.text gets displayed before timeInSeconds gets counted down. :thinking_Emoji: xD
    // However, some other games skip the first second, too.
}