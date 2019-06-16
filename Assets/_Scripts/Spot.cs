using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Spot
{
    public static Vector3[] spots =
    {
        new Vector3(-18f, 1.5f, -6f),
        new Vector3(27f, 1.5f, -6f),
        new Vector3(12f, 1.5f, -36f),
        new Vector3(0f, 1.5f, -36f)
    };

    public static Vector3[] spotDirections = //일단 보류
    {
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, 90f, 0f)
    };
}
