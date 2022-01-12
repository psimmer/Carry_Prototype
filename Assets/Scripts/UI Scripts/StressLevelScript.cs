using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressLevelScript : MonoBehaviour
{
    [SerializeField] private Slider sliderBar;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private AnimationCurve lerpCurve;
    [SerializeField] private float lerpDuration;
    [SerializeField] private playerScript player;

    public Slider SliderBar
    {
        get { return sliderBar; }
        set { sliderBar = value; }
    }

    private float timer = 0f;

    void Update()
    {

        timer += Time.deltaTime;
        sliderBar.value = Mathf.Lerp(sliderBar.minValue, player.CurrentStressLvl, lerpCurve.Evaluate(timer / lerpDuration));

        // Changes the Color of the Stress Level based on the gradient.
        fill.color = gradient.Evaluate(sliderBar.normalizedValue);
    }
}