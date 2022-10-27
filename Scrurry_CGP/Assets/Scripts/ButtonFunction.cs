using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isPaused = false;
    
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
         isPaused = false;
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    
    public void ResetB()
    {
        SceneManager.LoadScene("bathroom");
        
        Time.timeScale = 1f;
         isPaused = false;
    }
    public void ResetL()
    {
        SceneManager.LoadScene("Living room");

        Time.timeScale = 1f;
         isPaused = false;
    }

    public void ResetR()
    {
        SceneManager.LoadScene("RoachNest");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Next()
    {
        SceneManager.LoadScene("Living room");

        Time.timeScale = 1f;
        isPaused = false;
    }
     public void NextB()
    {
        SceneManager.LoadScene("bathroom");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

        Time.timeScale = 1f;
        isPaused = false;
    }
}
