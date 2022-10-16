using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    Runner runner;
   [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        runner = player.GetComponent<Runner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider roach)
    {
        runner.movespeed = 3;

    }
   void OnTriggerExit(Collider roach)
   {
    runner.movespeed = 16;
   }
}
