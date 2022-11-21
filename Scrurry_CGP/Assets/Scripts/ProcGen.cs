using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGen : MonoBehaviour
{
    public GameObject Ball,Spider,Cat,PowerUp1;
    public Transform player,b1,b2;
    public float distance = 50;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",3,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        int spawnChance = Random.Range(0,100);
        GameObject go = null;
        string type = "";
        if(spawnChance > 90)
        {
           go = PowerUp1;
           type = "p";
        }
        else if(spawnChance > 80)
        {
            go = Cat;
            type = "c";
        }
        else if(spawnChance > 50)
        {
            go = Spider;
            type = "s";
        }                                                          
        else 
        {
            go = Ball;
            type = "b";
        }
    
        Vector3 pos = player.position;
        pos.z += distance;
        pos.x = Random.Range(b1.position.x,b2.position.x);
        go = Instantiate(go,pos,Quaternion.identity);
        if(type == "s")
        {
           var ef = go.GetComponent<EnemyFollower>();
           ef.Player = player;
        } 
          /* else if(type == "c" )
        {
           var t = go.GetComponent;
        }
        else if(type == "p")
        {
            
        }                                                          
        else if(type == "b")
        {
           //go.AddComponent<MeleeDamage>();        
        }*/
    }
}
