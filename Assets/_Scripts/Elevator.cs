using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    float velocity = 1f;
    float y;
    private void Update()
    {
        y = transform.position.y;
        y += velocity * Time.deltaTime;

        if (y > 2.5f)
        {
            y = 2.5f;
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
