﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RePositonDekay());
    }

    IEnumerator RePositonDekay()
    {
        while(true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(5);
        }
    }
    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        Debug.Log("X,Z: " + x.ToString("F2") + ", " + z.ToString("F2"));
        transform.position = new Vector3(x, 0.0f, z);
    }
}
