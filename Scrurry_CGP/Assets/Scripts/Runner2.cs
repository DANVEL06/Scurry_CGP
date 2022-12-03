using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public bool wallKnock=false;
    public bool wallKnockDown=false;
    public int mult = 1;
    public float knockTime = 1.0f;
    public float wallKnockTime = .001f;
    public bool powerUp_DisableScurryWait= false;
    private float currentTime =0;

    public float wallNorthBorder;
    public float wallSouthBorder;

    public GameObject speedParticlesObject1;
    public GameObject speedParticlesObject2;

    [SerializeField]
    private Image imageCooldown;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI WincrumbText;
    public TextMeshProUGUI LosecrumbText;
    private int count;

    public int sceneNumber; //0- is endless
    public TextMeshProUGUI HighscoreText;
    public TextMeshProUGUI HighscoreText2;

    // Start is called before the first frame update
    void Start()
    {
         count = 0;
        
        countText.text = "" + count.ToString();
        WincrumbText.text = "Crumb Total: " + count.ToString();
        LosecrumbText.text = "Crumb Total: " + count.ToString();

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

      //For walls. If the wall pushes the player down the screen then Knockdown = true 
        if (wallKnock == true)
        {
            if (wallKnockDown == true) {
                var currentPos = transform.localPosition;
                Vector3 updatedPos = new Vector3(wallNorthBorder, currentPos.y, currentPos.z);
                transform.localPosition = updatedPos;
            }
            else
            {
                var currentPos = transform.localPosition;
                Vector3 updatedPos = new Vector3(wallSouthBorder, currentPos.y, currentPos.z);
                transform.localPosition = updatedPos;
            }
        }
        
       //transform.Translate(userDirection * movespeed * Time.deltaTime); 
          if (Input.GetKey(KeyCode.D))  
        {  
            moveDirection += new Vector3(.15f , 0f, 0f);  
            //transform.Translate(0.1f , 0f, 0f);  
        }  
        if (Input.GetKey(KeyCode.A))  
        {  
            moveDirection += new Vector3(-.15f , 0f, 0f);  
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
                    speedParticlesObject1.GetComponent<ParticleSystem>().Stop();
                    speedParticlesObject2.GetComponent<ParticleSystem>().Stop();
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
        speedParticlesObject1.GetComponent<ParticleSystem>().Play();
        speedParticlesObject2.GetComponent<ParticleSystem>().Play();
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

    public void WallKnockback(bool wallKnockDownGive, float border)
    {
        wallKnock = true;

        if (wallKnockDownGive == true)
        {
            wallNorthBorder = border;
        }
        else
        {
            wallSouthBorder = border;
        }

        wallKnockDown = wallKnockDownGive;
        Invoke("DisableWallKnockback", knockTime);
    }
    void DisableWallKnockback()
    {
        wallKnock = false;
    }


    public void DisableSpeedChange()
    {
        speedParticlesObject1.GetComponent<ParticleSystem>().Stop();
        speedParticlesObject2.GetComponent<ParticleSystem>().Stop();

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

   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            count += 1;

            countText.text = "" + count.ToString();
            WincrumbText.text = "Crumb Total: " + count.ToString();
            LosecrumbText.text = "Crumb Total: " + count.ToString();

            switch (sceneNumber)
            {
                case 1:
                    if (!PlayerPrefs.HasKey("highscore1"))
                    {
                        PlayerPrefs.SetInt("highscore1", 0);
                    }

                    if (count > PlayerPrefs.GetInt("highscore1")){
                        PlayerPrefs.SetInt("highscore1", count);
                    }

                    HighscoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore1").ToString();
                    HighscoreText2.text = "HighScore: " + PlayerPrefs.GetInt("highscore1").ToString();
                    break;

                case 2:
                    if (!PlayerPrefs.HasKey("highscore2"))
                    {
                        PlayerPrefs.SetInt("highscore2", 0);
                    }

                    if (count > PlayerPrefs.GetInt("highscore2")){
                        PlayerPrefs.SetInt("highscore2", count);
                    }

                    HighscoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore2").ToString();
                    HighscoreText2.text = "HighScore: " + PlayerPrefs.GetInt("highscore2").ToString();
                    break;

                case 3:
                    if (!PlayerPrefs.HasKey("highscore3"))
                    {
                        PlayerPrefs.SetInt("highscore3", 0);
                    }

                    if (count > PlayerPrefs.GetInt("highscore3")){
                        PlayerPrefs.SetInt("highscore3", count);
                    }

                    HighscoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore3").ToString();
                    HighscoreText2.text = "HighScore: " + PlayerPrefs.GetInt("highscore3").ToString();
                    break;

                case 4:
                    if (!PlayerPrefs.HasKey("highscore4"))
                    {
                        PlayerPrefs.SetInt("highscore4", 0);
                    }

                    if (count > PlayerPrefs.GetInt("highscore4")){
                        PlayerPrefs.SetInt("highscore4", count);
                    }

                    HighscoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore4").ToString();
                    HighscoreText2.text = "HighScore: " + PlayerPrefs.GetInt("highscore4").ToString();
                    break;

                case 5:
                    if (!PlayerPrefs.HasKey("highscore5"))
                    {
                        PlayerPrefs.SetInt("highscore5", 0);
                    }

                    if (count > PlayerPrefs.GetInt("highscore5")){
                        PlayerPrefs.SetInt("highscore5", count);
                    }

                    HighscoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore5").ToString();
                    HighscoreText2.text = "HighScore: " + PlayerPrefs.GetInt("highscore5").ToString();
                    break;

                case 6:
                    if (!PlayerPrefs.HasKey("highscore6"))
                    {
                        PlayerPrefs.SetInt("highscore6", 0);
                    }

                    if (count > PlayerPrefs.GetInt("highscore6")){
                        PlayerPrefs.SetInt("highscore6", count);
                    }

                    HighscoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore6").ToString();
                    HighscoreText2.text = "HighScore: " + PlayerPrefs.GetInt("highscore6").ToString();
                    break;

                case 7:
                    if (!PlayerPrefs.HasKey("highscore7"))
                    {
                        PlayerPrefs.SetInt("highscore7", 0);
                    }

                    if (count > PlayerPrefs.GetInt("highscore7")){
                        PlayerPrefs.SetInt("highscore7", count);
                    }

                    HighscoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore7").ToString();
                    HighscoreText2.text = "HighScore: " + PlayerPrefs.GetInt("highscore7").ToString();
                    break;

                case 8: //DLC
                    if (!PlayerPrefs.HasKey("highscore8"))
                    {
                        PlayerPrefs.SetInt("highscore8", 0);
                    }

                    if (count > PlayerPrefs.GetInt("highscore8")){
                        PlayerPrefs.SetInt("highscore8", count);
                    }

                    HighscoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore8").ToString();
                    HighscoreText2.text = "HighScore: " + PlayerPrefs.GetInt("highscore8").ToString();
                    break;

                case 9:
                    if (!PlayerPrefs.HasKey("highscore9"))
                    {
                        PlayerPrefs.SetInt("highscore9", 0);
                    }

                    if (count > PlayerPrefs.GetInt("highscore9")){
                        PlayerPrefs.SetInt("highscore9", count);
                    }

                    HighscoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore9").ToString();
                    HighscoreText2.text = "HighScore: " + PlayerPrefs.GetInt("highscore9").ToString();
                    break;

                case 10:
                    if (!PlayerPrefs.HasKey("highscore10"))
                    {
                        PlayerPrefs.SetInt("highscore10", 0);
                    }

                    if (count > PlayerPrefs.GetInt("highscore10")){
                        PlayerPrefs.SetInt("highscore10", count);
                    }

                    HighscoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore10").ToString();
                    HighscoreText2.text = "HighScore: " + PlayerPrefs.GetInt("highscore10").ToString();
                    break;

                default:
                    break;
            }
        }
    }    
}
