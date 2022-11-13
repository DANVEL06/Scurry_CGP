using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallKnockBackSouth : MonoBehaviour
{
   public Runner2 runner2;
  // public Animator animator;
     [SerializeField] Collider player;
     private int counter;

   // public float hitCooldown;
    private float timecounter;
    private bool hitTrigger;

    public float wallSouthBorder;

    // Awake is called before Start
    void Awake()
    {
        //getting component storing it in the runner2 variable.
        runner2 = player.GetComponent<Runner2>();

    }

    // Update is called once per frame
    void Update()
    {
       /* if (hitTrigger == true){
        timecounter+=Time.deltaTime;
        if(timecounter>hitCooldown)
        {
          timecounter = 0;
          animator.SetBool("isHit", false);
          hitTrigger = false;
          Debug.Log("is working");
        }*/
    }
    
   void OnTriggerEnter(Collider player)
   {
      /*hitTrigger = true;
      animator.SetBool("isHit", true);*/
      Debug.Log("Collision detected");
      //calling knockback function
     player.GetComponent<Runner2>().WallKnockback(false,wallSouthBorder);
   }
}
