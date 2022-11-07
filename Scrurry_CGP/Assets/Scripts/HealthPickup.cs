using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Health health;
    [SerializeField] GameObject player;
    public int heal = 5;

    public GameObject healthParticleObject;
    // Start is called before the first frame update
    void Awake()
    {
        health = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider player)
    {
      if(health.currentHealth < health.maxHealth)
      {
        healthParticleObject.GetComponent<ParticleSystem>().Play();
        healthParticleObject.GetComponent<AudioSource>().Play();

        health.currentHealth = health.currentHealth + heal;
            Destroy(gameObject);
      }  
    
    }


}
