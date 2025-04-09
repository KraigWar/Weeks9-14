using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;


public class PlayerMovement : MonoBehaviour
{
    private bool incampfire = false;
    public Healing healingScript;
    public GameObject heallll;
    public UnityEvent ClickingGround;
    public Transform camp;
    private Vector3 Clicked;
    public float dis = 1f;
    public float t;
    public float speed = 5;
    public Coroutine moving;


    //public Button healBut;
    void Start()
    {
        Clicked = transform.position;
        ClickingGround.AddListener(clickGround);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickingGround.Invoke();
        }
        Vector2 line = transform.position - camp.position;
        float dist = line.magnitude;


        if (dist < dis && !incampfire)
        {
            StopCoroutine(moving);
            ClickingGround.RemoveAllListeners();
            heallll.SetActive(true);
            Button Comp = heallll.GetComponent<Button>();
            Comp.onClick.AddListener(healingScript.starting);
            Debug.Log("i am here");
            incampfire = true;
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

        if (moving != null)
        {
            StopCoroutine(moving);
        }
        Clicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Clicked.z = transform.position.z;

        moving = StartCoroutine(amMoving());


    }
}



