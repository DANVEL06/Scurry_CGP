using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockHandler : MonoBehaviour
{
    //all them buttons
    public GameObject[] buttonArray;
    public GameObject[] buttonIMAGEarray;

    public int buttonNUM;

    [SerializeField] Button[] buttons;
    int unlockedLevelsNumber;

    // Start is called before the first frame update
    void Start()
    {
        //make button array

        if (!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }

        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");

      //  for (int i = 0; i < buttons.Length; i++)
       // {
            for (int i = 0; i < buttonNUM; i++)
            {

                buttons[i].interactable = false;
                buttonIMAGEarray[i].SetActive(true);
                buttonArray[i].SetActive(false);
                //buttons[i].interactable = false;
                //change buttons to images
            }
      //  }


 
         unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");

        for (int i=0; i<unlockedLevelsNumber; i++) {

            buttons[i].interactable = true;
            buttonArray[i].SetActive(true);
            buttonIMAGEarray[i].SetActive(false);
             //buttons[i].interactable = true;
        }

        Debug.Log("levelsUnlocked: " + unlockedLevelsNumber);
    }
}