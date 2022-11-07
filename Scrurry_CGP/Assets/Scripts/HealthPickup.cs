using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Health health;
    [SerializeField] GameObject player;
    public int heal = 5;
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
       health.currentHealth = health.currentHealth + heal;
       Destroy(gameObject);
      }  
    
    }


}
