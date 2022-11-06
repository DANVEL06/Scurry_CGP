using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Deadman : MonoBehaviour
{
    Health health;
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        health = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.isDead == false)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
