using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth = 5;
    public int maxHealth = 5;
    public bool isDead = false;
    public HealthBar healthBar;
    public GameObject loseUI;
    public GameObject scurryBtn;
    public Animator healthAnimator;
    public static bool isPaused = false;
    public bool isInvincible = false;
    public int cantTouchThis = 5;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        loseUI.gameObject.SetActive(false);
        scurryBtn.gameObject.SetActive(true);
    }

    public void Damage(int d)
    {
        if(isInvincible == true)
        {
            return;
        }

        currentHealth -= d;
        
        if (currentHealth <= 0)
        {
            isDead = true;
            loseUI.gameObject.SetActive(true);
            scurryBtn.gameObject.SetActive(false);

            Time.timeScale = 0f;
            isPaused = true;
        }
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Weapon"))
        {
            Damage(1);
            Debug.Log("ow");
        }

        healthBar.SetHealth(currentHealth);
    }

    public void Invincibility()
    {
        isInvincible = true;
        Invoke("NotInvincible", cantTouchThis);
    }
    public void NotInvincible()
    {
        isInvincible = false;
    }

}
