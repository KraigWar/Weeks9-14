using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    //delcaring what the current health of the player and the value it should have
    public float curHealth = 20;
    //delcaring the slider to have my image fill like a slider for later
    public Slider slide;
    //t to track a timer
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        
        //setting a minimum and maximum value of the slider to have a relative amount(Easier to see it as 100% hp vs 10% being the max)
        slide.minValue = 0;
        slide.maxValue = 100;
        //setting the players health to be what I delcared it should be earlier
        slide.value = curHealth;
    }
    //function to start the corountine and to be assigned to different events
    public void starting()
    {
        
        StartCoroutine(Increase());
        

    }
    IEnumerator Increase()
    {
        //setting 0 to 0 just in case and mishaps occur when pressing the button for the first time
        t = 0;
        //while statment to say "while t is less than 10 increase its value by 1 over time by increasing t"
        while (t < 10)
        {
            slide.value++;
            t += Time.deltaTime;
            yield return null;
        }
        
    }
}
