using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    private int dontMove = 0;

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
                
                transform.position = new Vector3(
                   transform.position.x + touch.deltaPosition.x * speedModifier,
                   transform.position.y + touch.deltaPosition.y * dontMove,
                   transform.position.z + touch.deltaPosition.y * dontMove);
                
            }
        }
    }
}
