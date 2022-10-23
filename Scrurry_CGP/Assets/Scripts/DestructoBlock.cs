using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestructoBlock : MonoBehaviour
{
    Runner2 runner;
    [SerializeField] GameObject player;

     public GameObject loseUI;

    // Start is called before the first frame update
    void Start()
    {
        runner = player.GetComponent<Runner2>();
        loseUI.gameObject.SetActive(false);
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

            loseUI.gameObject.SetActive(true);
        }

    }
}
