using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    public float curHealth = 20;
    public Slider slide;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        
 
        slide.minValue = 0;
        slide.maxValue = 100;
        slide.value = curHealth;
    }

    public void starting()
    {
        StartCoroutine(Increase());
        

    }
    IEnumerator Increase()
    {
        t = 0;
        while (t < 10)
        {
            slide.value++;
            t += Time.deltaTime;
            yield return null;
        }
        
    }
}
