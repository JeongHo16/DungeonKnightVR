using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 10; i++)
            Debug.Log(Random.Range(0f, 1f));
    }

    void Update()
    {

    }
}
