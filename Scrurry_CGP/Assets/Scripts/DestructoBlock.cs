using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestructoBlock : MonoBehaviour
{
    [SerializeField] GameObject player;
    Runner2 runner;

     public GameObject loseUI;
     public GameObject scurryBtn;

    // Start is called before the first frame update
    void Start()
    {
        runner = player.GetComponent<Runner2>();
        loseUI.gameObject.SetActive(false);
        scurryBtn.gameObject.SetActive(true);
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
            scurryBtn.gameObject.SetActive(false);
        }

    }
}
