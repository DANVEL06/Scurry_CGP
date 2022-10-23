using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    Runner2 runner;
   [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        runner = player.GetComponent<Runner2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider roach)
    {
        runner.movespeed = 200;
        runner.normalSpeed = 200;
    }
   public void OnTriggerExit(Collider roach)
   {
        runner.movespeed = 3000;
        runner.normalSpeed = 3000;
   }
}
