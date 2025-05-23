using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    AudioSource audio;

    SpriteRenderer sr;
    Animator animator;
    public float speed = 2;
    public List<AudioClip> steps;
    public bool canRun = true;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");


        sr.flipX = (direction < 0);
        animator.SetFloat("Movement",Mathf.Abs(direction));


        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            canRun = false;
        }



       if (canRun == true) { 
        transform.position += transform.right * direction * speed * Time.deltaTime;
        }


    }


    public void AttackHasFinished()
    {
        Debug.Log("The attack has finished");
        canRun = true;
    }



    public void footLanded()
    {
        audio.clip = steps[(int)Random.Range(0,4)];
        audio.Play();


    }



}
