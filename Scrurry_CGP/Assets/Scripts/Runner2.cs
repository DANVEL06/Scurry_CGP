using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Runner2 : MonoBehaviour
{
    public int movespeed = 3000;
    public int normalSpeed = 3000;
    public int puddleSpeed = 500;
    public int scurryspeed = 6000;
    public int fastSpeed = 6000;
    public Vector3 userDirection = Vector3.forward;

    public float speedBoostDuration = 2.0f;

    public Button ScurryButton;
    public float scurryButtonCooldown = 5.0f;
    public float framePersecond =2;
    public bool goingFast = false, scurryWait = false;
    public Vector3 moveDirection;
    public Rigidbody rb;
    public bool isKnocked = false;
    public int mult = 1;
    public float knockTime = 1.0f;
    public bool powerUp_DisableScurryWait= false;
    private float currentTime =0;

    [SerializeField]
    private Image imageCooldown;


    // Start is called before the first frame update
    void Start()
    {
        ScurryButton.onClick.AddListener(SpeedChange);
        imageCooldown.fillAmount = 1.0f;
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
            currentTime += Time.deltaTime;

            imageCooldown.fillAmount = currentTime / scurryButtonCooldown; //calculates percentage of button filled and puts it in scurry's fillAmount
            Debug.Log("currentTime =" + currentTime);

            if (speedBoostDuration > 0)
            {
                Debug.Log("its working");

                speedBoostDuration -= Time.deltaTime;
                if (speedBoostDuration <= 0.01f)
                {
                    movespeed = normalSpeed;
                    Debug.Log("so slow again");
                    goingFast = false;
                    speedBoostDuration = 2.0f;
                    
                    currentTime = 0;
                    
                }
            }
        }

        if (scurryWait == true)
        {
            currentTime += Time.deltaTime;
            imageCooldown.fillAmount = currentTime / scurryButtonCooldown;
        }
        else
        {
            currentTime = 0;
            imageCooldown.fillAmount = 1.0f;
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
        if(scurryWait == true)
        {
            Debug.Log("Too tired");
            return;
        }
        if(goingFast == true)
        {
            Debug.Log("Player already Scurried");
            return;
        }

        Debug.Log("is working");
        movespeed = scurryspeed;
        Debug.Log("gotta go fast");
        goingFast = true;

        //goingFast = true;
        
        Invoke("DisableSpeedChange",speedBoostDuration);
        if(powerUp_DisableScurryWait == false)
        {
        scurryWait = true;
        
        Invoke("ChillOut",scurryButtonCooldown);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = moveDirection * movespeed * Time.deltaTime;
    }
    

    public void Knockback()
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

    public void DisableSpeedChange()
    {
        goingFast = false;
        movespeed = normalSpeed;
    }
    public void ChillOut()
    {
        scurryWait = false;
    }
    public void PowerUp_DisableScurryWait()
    {
        Debug.Log("powerup ENABLED");
        powerUp_DisableScurryWait = true;

        Invoke("Disable_PowerUp_DisableScurryWait",10);
    }
   public void Disable_PowerUp_DisableScurryWait()
   {
    Debug.Log("powerup DISABLED");
    powerUp_DisableScurryWait = false;
   }
}
