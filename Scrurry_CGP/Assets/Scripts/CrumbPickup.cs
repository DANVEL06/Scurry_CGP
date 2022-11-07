using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbPickup : MonoBehaviour
{
    public GameObject crumbAudioObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
       {
            crumbAudioObject.GetComponent<AudioSource>().Stop();
            crumbAudioObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
       }
    }
}
