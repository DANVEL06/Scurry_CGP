using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;

    public int sceneNumber;
    public TextMeshProUGUI HighscoreText;

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

        if(sceneNumber == 0)
        {
            if (!PlayerPrefs.HasKey("endlessHighscore"))
            {
                PlayerPrefs.SetFloat("endlessHighscore", 0);
            }

            if(timer > PlayerPrefs.GetFloat("endlessHighscore"))
            {
                PlayerPrefs.SetFloat("endlessHighscore", timer);
            }

            string secondsHigh = (PlayerPrefs.GetFloat("endlessHighscore") % 60).ToString("f2");
            string minutesHigh = ((int)(PlayerPrefs.GetFloat("endlessHighscore")) / 60).ToString();


            HighscoreText.text = "HighScore: " + minutesHigh +";"+ secondsHigh ;
        }
    }
}
