using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public ParticleSystem firework;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firework.gameObject.SetActive(!firework.gameObject.activeInHierarchy);
 
       }
        if (Input.GetMouseButtonDown(0))
        {
            if (firework.isPlaying == true)
            {
                firework.Stop();

            }
            else
            {
                firework.Play();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            firework.Emit(10);
        }
       
    }

}
