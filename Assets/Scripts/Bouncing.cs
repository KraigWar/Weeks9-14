using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    public float speed = 0.05f;
    public AnimationCurve curve;
    Vector2 startingpos;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        startingpos = Vector2.left * 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        //transform


        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);

        if (screenPos.x > Screen.width)
        {

            pos = startingpos;
        }
        
        

        transform.position = pos;
    }
}