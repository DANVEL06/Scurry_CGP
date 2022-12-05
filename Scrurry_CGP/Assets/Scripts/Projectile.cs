using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   public bool canmove = true;
    public float projectileSpeed = 1;
    public string tag = "";
    // Start is called before the first frame update
    void Start()
    {
         CapsuleCollider SC = gameObject.GetComponent<CapsuleCollider>();
        //Checks all colliders in a particular range and stores every collider it strikes in 
        // an array.
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + SC.center, SC.radius);
        //Checks if we have at least one collider in the array.

     if(hitColliders.Length >= 1)
     {
        //stores tag of the hit game object in global string. this stores tag of the first thing
        //hit.
    tag = hitColliders[0].gameObject.tag;
    Debug.Log(tag + "HEREHERE");
     }
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canmove == false)
        {
            return;
        }
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
    }
    void OnTriggerEnter(Collider c)
    {
        if(c.CompareTag(tag) == true)
        {
            return;
        }
        canmove = false;
    }
}