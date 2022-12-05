using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject player; 
    public GameObject projectilePrefab;
    public float range = 10;
    public bool canShoot = true;
    public float shootTime = 2;
    public Transform boom;
    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }
    void CanShootAgain()
    {
        canShoot = true;
    }
    void Shoot_()
    {
        transform.LookAt(player.transform);
        Vector3 angles = new Vector3(0,transform.localEulerAngles.y,0);
        transform.localEulerAngles = angles;
          Instantiate(projectilePrefab, boom.position, transform.rotation);
        //instantiate bullet transform.lookatplayer transform.look at first 
        canShoot = false;
        Invoke("CanShootAgain",shootTime);
    }
    // Update is called once per frame
    void Update()
    {
        if(canShoot == false)
        {
            return;
        }

        float dist = Vector2.Distance(player.transform.position, transform.position);
        if(dist <= range)
        {
            Shoot_();
        }
    }
}