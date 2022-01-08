using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleScript : MonoBehaviour
{
    [SerializeField] private float start = 1f;
    [SerializeField] private float end = 180f;

    private Quaternion dayStart;
    private Quaternion dayEnd;
    float speed = 0.1f;

    // The speed is calculatet to 6 minutes till the lerp finish
    void Start()
    {
        dayStart = Quaternion.Euler(start, 90, 0);
        dayEnd = Quaternion.Euler(end, 90, 0);
    }

    void Update()
    {
        LerpStart();
    }


    public void LerpStart()
    {
        transform.rotation = Quaternion.Lerp(dayStart, dayEnd, Time.time * (speed / (6 * 6)));
        //Debug.Log((int)Time.time);
        Debug.Log("Hello i am the sun and i dont know why i am still rotating in the menu scene");
        //Debug.Log(transform.rotation);
    }

}
