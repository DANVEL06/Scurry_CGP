using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackTrigger : MonoBehaviour
{
   public Runner2 runner2;
     [SerializeField] Collider player;

    // Awake is called before Start
    void Awake()
    {
        //getting component storing it in the runner2 variable.
        runner2 = player.GetComponent<Runner2>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void OnTriggerEnter(Collider player)
   {
    Debug.Log("Collision detected");
    //calling knockback function
    //player.GetComponent<Runner2>().Knockback();
   }
}
