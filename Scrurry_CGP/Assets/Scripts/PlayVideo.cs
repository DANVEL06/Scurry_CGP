using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoplayer;
    public AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartVideo());
    }
    IEnumerator StartVideo()
    {
        videoplayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoplayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoplayer.texture;
        videoplayer.Play();
        audiosource.Play();
    }
}
