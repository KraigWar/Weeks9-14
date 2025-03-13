using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//THIS IS IMPORTANT, YOU NEED THE LINE ABOVE ME

public class NewEvent : MonoBehaviour
{
    public RectTransform banana;

    //make this public to see in inspector
    //Always start it with 'On'
    //THis is declareing it
    public UnityEvent OnTimerHasFinished;

    public float timerLength = 3;
    public float t;


    private void Update()
    {
        t += Time.deltaTime;
        if(t > timerLength)
        {
            t = 0;
            //This will trigger everything that is within the UnityEvent. EVERY FUNCTION
            //Also known as raising the event
            
            OnTimerHasFinished.Invoke();
            //OnSomethingHappened.AddListener(MyFunctionName);
            //This will add things to the invoke list
            //.RemoveListner(MyFunctionName) to remove something from the invoke list
        }
    }


    public void MouseJustEnteredImage()
    {
        Debug.Log("Mouse Just Entered Me!");
        banana.localScale = Vector3.one * 1.2f;
    }

    public void MouseJustLeftImage()
    {
        Debug.Log("Mouse Just Left Me!");
        banana.localScale = Vector3.one;
    }

  
}
