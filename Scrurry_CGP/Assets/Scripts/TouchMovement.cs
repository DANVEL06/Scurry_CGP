using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    private int dontMove = 0;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(
                    rb.velocity.x + touch.deltaPosition.x * speedModifier,
                    rb.velocity.y + touch.deltaPosition.y * dontMove,
                    rb.velocity.z + touch.deltaPosition.y * dontMove);
             
                
                 // transform.position = new Vector3(
                  // transform.position.x + touch.deltaPosition.x * speedModifier,
                  // transform.position.y + touch.deltaPosition.y * dontMove,
                  // transform.position.z + touch.deltaPosition.y * dontMove);
                
            }
        }
    }
}
