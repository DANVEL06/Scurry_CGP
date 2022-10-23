using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Runner2 : MonoBehaviour
{
    public int movespeed = 10;
    public int normalSpeed = 10;
    public int scurryspeed = 50;
    public int fastSpeed = 50;
    public Vector3 userDirection = Vector3.forward;

    public float speedBoostDuration = 2.0f;

    public Button ScurryButton;
    public float scurryButtonCooldown = 5.0f;
    public float framePersecond =2;
    private bool goingFast = false;
    public Vector3 moveDirection;
    public Rigidbody rb;
    public bool isKnocked = false;
    public int mult = 1;
    public float knockTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        ScurryButton.onClick.AddListener(SpeedChange);
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.K))
      {
        Knockback();
      }
       moveDirection = userDirection * mult;
        
       //transform.Translate(userDirection * movespeed * Time.deltaTime); 
          if (Input.GetKey(KeyCode.D))  
        {  
            moveDirection += new Vector3(1f , 0f, 0f);  
            //transform.Translate(0.1f , 0f, 0f);  
        }  
        if (Input.GetKey(KeyCode.A))  
        {  
            moveDirection += new Vector3(-1f , 0f, 0f);  
        }
       Debug.Log(moveDirection);
        if (goingFast)
        {
            if (speedBoostDuration > 0)
            {
                speedBoostDuration -= Time.deltaTime;
                if (speedBoostDuration <= 0.01f)
                {
                    movespeed = normalSpeed;
                    Debug.Log("so slow again");
                    goingFast = false;
                    speedBoostDuration = 2.0f;
                    
                
                }
            }
        }

        /*if (scurryButtonCooldown > 0)
        {
            scurryspeed = normalSpeed;
            scurryButtonCooldown -= Time.deltaTime;
            Debug.Log("can't run");

        }
        if (scurryButtonCooldown <= 0.01f)
        {
            scurryspeed = fastSpeed;
            Debug.Log("speedy once more");
            scurryButtonCooldown = 5.0f;
        }

        if (movespeed > 11)
        {
            
        }*/
    }

    void SpeedChange()
    {
        Debug.Log("is working");
        movespeed = scurryspeed;
        Debug.Log("gotta go fast");
        goingFast = true;
    }
    void FixedUpdate()
    {
        rb.velocity = moveDirection * movespeed * Time.deltaTime;
    }
    

    void Knockback()
    {
        isKnocked = true;
        mult = -1;
        Invoke("DisableKnockback",knockTime);
    }
     void DisableKnockback()
    {
        isKnocked = false;
        mult = 1;
    }
}
