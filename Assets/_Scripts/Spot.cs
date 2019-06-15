using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public static Vector3[] spots = 
        {
        new Vector3(-3.0f, 0.5f, 3.0f),
        new Vector3(3.0f, 0.5f, 3.0f),
        new Vector3(-3.0f, 0.5f, -3.0f),
        new Vector3(3.0f, 0.5f, -3.0f)
    };
}
