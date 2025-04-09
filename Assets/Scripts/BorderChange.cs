using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderChange : MonoBehaviour
{
    public Image myIMG;
    public Sprite Lowhealth;
    public Sprite healing;
    public Button healingButt;
    void Start()
    {
        myIMG.sprite = Lowhealth;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //public void changeBord()
    //{
    //    HealthBar
    //    healingButt.onClick.AddListener()
    //}
}
