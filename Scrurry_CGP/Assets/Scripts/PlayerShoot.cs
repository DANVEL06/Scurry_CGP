using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject player; 
    public GameObject projectilePrefab;
    public bool canShoot = true;
    public float shootTime = 1;
    public Transform pow;
    // Start is called before the first frame update

    void CanShootAgain()
    {
        canShoot = true;
    }
    
    // Update is calltheed once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.F))
       {
          Instantiate(projectilePrefab, pow.position, transform.rotation);
        //instantiate bullet transform.lookatplayer transform.look at first 
        Debug.Log("pew");
        canShoot = false;
        Invoke("CanShootAgain",shootTime);
       }
        if(canShoot == false)
        {
            return;
        }
        
    }
    
}
