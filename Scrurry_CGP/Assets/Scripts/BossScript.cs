using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript: MonoBehaviour
{
    public Transform b1;
    public Transform b2;
    public int dist = 20;
    public int moveSpeed = 10;
    public Transform player;
    public int direction = 1;
    public float mult = 1;

    // Start is called before the first frame update
    void Start()
    {
     Setup();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frac = (Time.time - start)/moveSpeed;
         if(lerpA) a = Vector3.Lerp(b2.position,b1.position,frac);
         else a = Vector3.Lerp(b1.position,b2.position,frac);
         a.z += dist;
         transform.position = a;
         if(frac >= 1) {Setup();}
        //transform.position = player.position + player.transform.forward * dist;
       // transform.position += transform.right * direction * Time.deltaTime * mult;
    }
    Vector3 a;
    Vector3 b;
    bool lerpA = false;
    float start,frac;
    void Setup()
    {
        start = Time.time;
        frac = 0;
        lerpA = !lerpA;
    }
}
