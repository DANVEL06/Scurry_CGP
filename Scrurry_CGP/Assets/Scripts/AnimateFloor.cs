using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateFloor : MonoBehaviour
{
    public float directionX = .5f;
    public float directionY = .5f;

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * directionX;
        float offsetY = Time.time * directionY;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
