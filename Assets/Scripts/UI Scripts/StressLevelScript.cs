using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressLevelScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private AnimationCurve lerpCurve;
    [SerializeField] private float lerpDuration;

    private float timer = 0f;

    void Update()
    {
        // Time measuring
        timer += Time.deltaTime;
        
        // For now the Stress Level just fills completly at the start of the game and has no effect.
        slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, lerpCurve.Evaluate(timer / lerpDuration));

        // Changes the Color of the Stress Level based on the gradient.
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}