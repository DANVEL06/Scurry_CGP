using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustPickup : MonoBehaviour
{
    public GameObject dustParticleObject;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
       {
            dustParticleObject.GetComponent<ParticleSystem>().Play();

            dustParticleObject.GetComponent<AudioSource>().Stop();
            dustParticleObject.GetComponent<AudioSource>().Play();

            Health h = other.GetComponent<Health>();
        h.Invincibility();
        Destroy(gameObject);
       }
    }
}
