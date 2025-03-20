using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoruntineMove : MonoBehaviour
{

    
    public Transform scaling;
    public AnimationCurve curve;
    [Range(0, 1)]
    public UnityEvent grow;

    public float t = 0;
    public float HowLongToGo;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(makeMeBigger());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator makeMeBigger()
    {
        t = 0;
        while(t > HowLongToGo) {
            t += Time.deltaTime;
        transform.localScale = Vector2.one * curve.Evaluate(t);
        yield return null;

            }
        grow.Invoke();

        }
    }








