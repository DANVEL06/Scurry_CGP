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
    }
    public void ResetL()
    {
        SceneManager.LoadScene("Living room");
    }

    public void ResetR()
    {
        SceneManager.LoadScene("RoachNest");
    }

    public void Next()
    {
        SceneManager.LoadScene("Living room");
    }
     public void NextB()
    {
        SceneManager.LoadScene("bathroom");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
