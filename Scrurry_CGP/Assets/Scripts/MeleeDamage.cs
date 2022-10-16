using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider target)
    {
        var h = target.gameObject.GetComponent<Health>();
        if (h != null)
        {
            h.Damage(damage);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
