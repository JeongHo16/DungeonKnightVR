using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitLight : MonoBehaviour
{
    void Update()
    {
        if (transform.rotation.x < 0f)
        {
            Vector3 ligth = new Vector3(0f, transform.rotation.y + 90f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(ligth);
        }
    }
}
