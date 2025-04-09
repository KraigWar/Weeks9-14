using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;
using JetBrains.Annotations;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //public Transform play;
    public Transform camp;
    private Vector3 Clicked;
    public float dis = 2f;
    public float t;
    public float speed = 5;
    public Coroutine moving;

    //public Button healBut;
    void Start()
    {
        Clicked = transform.position;
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (moving != null)
            {
                StopCoroutine(moving);
            }
            Clicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Clicked.z = transform.position.z;

            moving = StartCoroutine(amMoving());

        }




        Vector2 line = transform.position - camp.position;
        float dist = line.magnitude;


        if (dist < dis)
        {

            //addEventListener();
            Debug.Log("IM HERE");
            //    play.z = transform.position.z;
            //}
        }
    }
        IEnumerator amMoving()
        {
            while (transform.position != Clicked)
            {
                transform.position = Vector3.MoveTowards(transform.position, Clicked, speed * Time.deltaTime);

                yield return null;
            }
        }
  
      
        public void clickGround()
    {

    }

        //}

        //    public void moves()
        //{

        //} 

        //IEnumerator moving()
        //{
        //    while(madeIt == false)
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position,Target, s * t);
        //        yield return null;
        //    }

        //madeIt = true;

        //}


    }

