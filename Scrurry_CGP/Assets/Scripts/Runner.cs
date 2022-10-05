using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
public int movespeed = 10;
public Vector3 userDirection = Vector3.forward;
public int scurryspeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(userDirection * movespeed * Time.deltaTime); 
          if (Input.GetKey(KeyCode.A))  
        {  
            transform.Translate(0.1f, 0f, 0f);  
        }  
        if (Input.GetKey(KeyCode.D))  
        {  
            transform.Translate(-0.1f, 0f, 0f);  
        }  
        if (Input.GetKey(KeyCode.F))
        {
            movespeed = scurryspeed;
        } 
    }
}
