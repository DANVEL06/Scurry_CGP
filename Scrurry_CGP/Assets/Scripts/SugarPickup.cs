using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarPickup : MonoBehaviour
{   
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
       Health h = other.GetComponent<Health>();
        h.Invincibility();
        Destroy(gameObject);
       }
    }
}
