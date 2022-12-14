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

    public void ResetBR()
    {
        SceneManager.LoadScene("Bedroom");
        
        Time.timeScale = 1f;
         isPaused = false;
    }
    public void ResetL()
    {
        SceneManager.LoadScene("Living room");

        Time.timeScale = 1f;
         isPaused = false;
    }

     public void ResetK()
    {
        SceneManager.LoadScene("Kitchen");

        Time.timeScale = 1f;
         isPaused = false;
    }

    public void ResetR()
    {
        SceneManager.LoadScene("RoachNest");

        Time.timeScale = 1f;
        isPaused = false;
    }
    public void ResetFY()
    {
        SceneManager.LoadScene("front yard");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void NextB()
    {
        SceneManager.LoadScene("bathroom");

        Time.timeScale = 1f;
        isPaused = false;
    }
    public void NextBed()
    {
        SceneManager.LoadScene("Bedroom");

        Time.timeScale = 1f;
        isPaused = false;
    }


    public void NextL()
    {
        SceneManager.LoadScene("Living room");

        Time.timeScale = 1f;
        isPaused = false;
    }
     
    public void NextK()
    {
        SceneManager.LoadScene("Kitchen");

        Time.timeScale = 1f;
        isPaused = false;
    }
    public void NextFY()
    {
        SceneManager.LoadScene("front yard");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ResetEndless()
    {
        SceneManager.LoadScene("EndlessMode");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void NextDLC1()
    {
        SceneManager.LoadScene("DLC 1");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ResetDLC1()
    {
        SceneManager.LoadScene("DLC 1");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void NextDLC2()
    {
        SceneManager.LoadScene("DLC 2");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ResetDLC2()
    {
        SceneManager.LoadScene("DLC 2");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void NextDLC3()
    {
        SceneManager.LoadScene("DLC 3");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ResetDLC3()
    {
        SceneManager.LoadScene("DLC 3");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void NextBoss()
    {
        SceneManager.LoadScene("BossFight");

        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void ResetBoss()
    {
        SceneManager.LoadScene("BossFight");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
