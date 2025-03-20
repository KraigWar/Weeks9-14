using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;

    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;



    public UnityEvent<int> OnTheHour;


    //the thing while doing
    Coroutine clockIsRunning;
    //things to do
    IEnumerator doOneHour;
    void Start()
    {
        clockIsRunning = StartCoroutine(MoveTheClock());
      
    }


    IEnumerator MoveTheClock()
    {
        while (true)
        {
            //one way to stop it at an hour thats very overwhelming
            //yield return doOneHour = StartCoroutine(MoveTheClockHandsOneHour());

            doOneHour = MoveTheClockHandsOneHour();
            yield return StartCoroutine(doOneHour);
        }
        
        
        
    }

    IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while (t < timeAnHourTakes)
        {
             
             t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes * Time.deltaTime));
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes * Time.deltaTime));
            //this makes the loop continue every frame while its less than 5
            yield return null;
        }
        
        hour++;
        if(hour == 13)
        {
            hour = 1;
        }

        //keep it into the corutine code but outside the while
        OnTheHour.Invoke(hour);
    }
    public void StopTheClock()
    {
        if (clockIsRunning != null)
        {
            StopCoroutine(clockIsRunning);
        }
        if (doOneHour != null)
        {
            StopCoroutine(doOneHour);
        }
    }
}
