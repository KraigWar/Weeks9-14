using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    SpriteRenderer sr;
    public float curHealth = 20;
    public Slider slide;
    public float t;
    public bool isHealing;
    // Start is called before the first frame update
    void Start()
    {
        isHealing = false;
 
        slide.minValue = 0;
        slide.maxValue = 100;
        slide.value = curHealth;
    }

    public void starting()
    {
        StartCoroutine(Increase());
        sr = GetComponent<SpriteRenderer>();

    }
    IEnumerator Increase()
    {
        t = 0;
        while (t < 1)
        {
            slide.value++;
            t += Time.deltaTime;
            yield return null;
        }
        isHealing = false;
    }
}
