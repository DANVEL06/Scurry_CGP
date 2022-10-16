using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public Transform footRoot;
    public bool crush;
    private Vector3 start;
    private Vector3 end;
    private float frac;
    private float startTime;
    public float crushTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //identifying crush as true
        if(crush == true)
        {
            frac = (Time.time - startTime)/crushTime;
            footRoot.transform.position = Vector3.Lerp(start,end,frac);
        }
    }

    void OnTriggerEnter(Collider shadow)
    {
        Debug.Log("collide");
        //setting crush as true
        crush = true;
        start = footRoot.position;
        end = start;
        end.y = 0;
        frac = 0;
        startTime = Time.time;
    }
}
