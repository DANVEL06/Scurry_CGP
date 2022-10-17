using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
