using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingJewels : MonoBehaviour
{
    public GameObject jewels;
    public GameObject jewel;
    public int jewelsNumber;

    void Start()
    {
        for (int i = 0; i < jewelsNumber; i++)
        {
            Vector3 position = new Vector3(Random.Range(-4.0f, 4.0f), 0.5f, Random.Range(-4.0f, 4.0f));
            Instantiate(jewel, position, Quaternion.identity).transform.parent = jewels.transform;
        }
    }


}
