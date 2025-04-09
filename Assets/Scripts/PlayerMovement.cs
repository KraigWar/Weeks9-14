using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;


public class PlayerMovement : MonoBehaviour
{
    //declaring a bool to later track if the player made it to the cmapfire
    private bool incampfire = false;
    //making a public class to drag the health bar into this script to later get component to add it to the onlcick event
    public Healing healingScript;
    //making a public class to drag the button into this script to later make it appear
    public GameObject heallll;
    //declaring the event for the functions that will be subscribed/unsubscribed to it
    public UnityEvent ClickingGround;
    //transoform class to drag the cmapfire site into the script to calculates its distance from the player
    public Transform camp;
    //variable to store the location of which the mouse is clicked
    private Vector3 Clicked;
    //distance variable for calculating how far from the campsite you need to be
    public float dis = 1f;
    //Variable for a timer
    public float t;
    //variable for the speed of the character
    public float speed = 5;
    //Storing the corotuine I will use into the variable
    public Coroutine moving;


    //public Button healBut;
    void Start()
    {
        //get the clicked position which will be nowhere for now
        Clicked = transform.position;
        //subscribing the ability to click the ground to use the coroutine to move the player
        ClickingGround.AddListener(clickGround);


    }

    // Update is called once per frame
    void Update()
    {
        //if statment that checks if you have left clicked anywhere
        if (Input.GetMouseButtonDown(0))
        {
            //invoke the event that includes the ability to move with the coroutine 
            ClickingGround.Invoke();
        }
        //Two variables that will track the distance between the player and the campsite to check if they are close enoguth yet
        Vector2 line = transform.position - camp.position;
        float dist = line.magnitude;

        //if statement to check if you are within distance of the campfire
        if (dist < dis && !incampfire)
        {
            //this will stop the corountine once you enter the area
            StopCoroutine(moving);
            //this will remove the ability to leave the area using the move coroutine so players can focus on just healing
            ClickingGround.RemoveAllListeners();
            //this will make the button appear on screen
            heallll.SetActive(true);
            //this will store the buttons 'button component' to add the onclick event of healing
            Button Comp = heallll.GetComponent<Button>();
            //this adds the healing script in the health bar and makes it possible for the button to heal the player
            Comp.onClick.AddListener(healingScript.starting);
            Debug.Log("i am here");
            //boolean to make sure the this if statment doesn't happen every from byt including the restrictions in the if statement above
            incampfire = true;
        }
    }
    IEnumerator amMoving()
    {
        //while statment for the coroutine that checks if your characters position is not where youve clicked
        while (transform.position != Clicked)
        {
            //this will lerp the player from the players current position to the clicked position over time
            transform.position = Vector3.Lerp(transform.position, Clicked, speed * Time.deltaTime);

            yield return null;
        }
    }

    //Function the coroutine to start, when to stop, and grabbing the clicked position
    public void clickGround()
    {
        //if statement that will stop the corountine if we are still movinf towards another location.
        if (moving != null)
        {
            StopCoroutine(moving);
        }
        //This will grab the players desired locaiton and store it in "clicked"
        Clicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Clicked.z = transform.position.z;
        //this will start the coroutine to move towards the clicked area
        moving = StartCoroutine(amMoving());


    }
}



