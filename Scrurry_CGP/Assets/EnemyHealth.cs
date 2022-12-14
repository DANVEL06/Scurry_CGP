using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 5;
    public int maxHealth = 5;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(int d) 
    {
        currentHealth -= d;
        if(currentHealth <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider c)
    {
        if(c.CompareTag("Weapon"))
        {
            Damage(1);
            Debug.Log("ow");
        }
    }

}
