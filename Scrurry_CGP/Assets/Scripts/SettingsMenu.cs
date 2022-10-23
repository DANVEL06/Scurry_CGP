using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    
    public void SetVolume (float sliderValue)
    {
        mixer.SetFloat("volume", Mathf.Log10 (sliderValue) * 20);
    }
}
