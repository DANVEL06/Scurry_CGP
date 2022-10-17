using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestructoBlock : MonoBehaviour
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

    void OnTriggerEnter(Collider poorsoul)
    {
        if(poorsoul.CompareTag("Player")||poorsoul.CompareTag("Enemy"))
        {
            runner.movespeed = 0;
            runner.normalSpeed = 0;
            SceneManager.LoadScene("SampleScene");

        }

    }
}
