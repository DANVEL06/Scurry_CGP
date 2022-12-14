using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopPickup : MonoBehaviour
{
    public GameObject goopParticleObject;

    // Start is called before the first frame update
    void Start()
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

           goopParticleObject.GetComponent<ParticleSystem>().Play();

           goopParticleObject.GetComponent<AudioSource>().Stop();
           goopParticleObject.GetComponent<AudioSource>().Play();

           Runner2 r2 = other.GetComponent<Runner2>();
            r2.PowerUp_DisableScurryWait();
            Destroy(gameObject);
       }
    }
}
