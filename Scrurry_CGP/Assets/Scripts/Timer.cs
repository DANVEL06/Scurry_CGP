using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;

     void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float timer = Time.time - startTime;

         string seconds = (timer % 60).ToString("f2");
         string minutes = ((int) timer / 60).ToString();
       
        timerText.text = minutes + ":" + seconds;
    }
}
