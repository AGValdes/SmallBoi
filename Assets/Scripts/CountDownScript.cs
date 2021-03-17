using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    
    void Start()
    {        
        timer = mainTimer;
        doOnce = true;
    }


    void Update()
    {

        //if(doOnce)
        //{
        //    timer += Time.deltaTime;
        //    uiText.text = timer.ToString("f");
        //}

        //else if (timer <= 0.0f && !doOnce)
        //{
        //    canCount = false;
        //    doOnce = true;
        //    uiText.text = "0.00";
        //    timer = 0.0f;
        //}
    }

}
