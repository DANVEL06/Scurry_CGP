using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
   public int amount = 1;
   public float rate = 1;
   public int ticks = 5;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           if(other.gameObject.GetComponent<DOT>() == null);
            {
             DOT dot = other.gameObject.AddComponent<DOT>();
             dot.dmgAmount = 2;
             dot.dmgRate = 1;
             dot.deathTicks = 5;
                print("DOT Attached");
            }
        }
    }
}
