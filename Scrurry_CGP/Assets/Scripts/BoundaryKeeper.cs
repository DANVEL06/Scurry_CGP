using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryKeeper : MonoBehaviour
{
    public Transform player; 
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos = transform.position;
        pos.z = player.position.z;
        transform.position = pos;
        Debug.Log($"<color=red>{player.transform.position} vs {transform.position}</color>");

    }
}
