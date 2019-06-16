using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    float velocity = 1f;
    float y;
    private void Update()
    {
        y = transform.position.y;
        y += velocity * Time.deltaTime;

        if (y > 1f)
        {
            y = 1f;
            velocity = -velocity;
        }

        if (y < 0f)
        {
            y = 0f;
            velocity = -velocity;
        }

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}

