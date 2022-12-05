using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOT : MonoBehaviour
{
    public int dmgAmount = 1;
    public float dmgRate = 1;
    public Health health;
    private float lastTime = 1;
    public int deathTicks = 5;
    public int currentTicks = 0; 
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        if(health == null)Destroy(this);
        if(health.currentHealth < 0 )Destroy(this);
        lastTime = Time.time;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time - lastTime > dmgRate)
        {
            DamageTick();
        }
    }
    void DamageTick()
    {
        lastTime = Time.time;
        health.Damage(dmgAmount);
        currentTicks++;
        if(currentTicks >= deathTicks)Destroy(this);

    }
}
