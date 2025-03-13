using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    public UnityEvent OnHourHasPassed;

    public float speed = -50;
    public float timerLength = 7;
    public float t;

    void Start()
    {
        speed = -50;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
        t += Time.deltaTime;
        if (t > timerLength)
        {
            t = 0;

            OnHourHasPassed.Invoke();

        }
    }
}
