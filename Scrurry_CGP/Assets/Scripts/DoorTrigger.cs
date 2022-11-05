using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    Runner2 runner;
    [SerializeField] GameObject player;
    public GameObject winUI;
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        winUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.CompareTag("Player"))
        {
            winUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }

    }
}
