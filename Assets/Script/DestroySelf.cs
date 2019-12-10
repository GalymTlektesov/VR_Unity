using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float timeDeath = 5.0f;
    void Start()
    {
        //Destroy(gameObject, timeDeath);
    }

    void Update()
    {
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
