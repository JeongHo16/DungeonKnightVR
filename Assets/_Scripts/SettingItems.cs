using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingItems : MonoBehaviour
{
    public GameObject trophys;
    public GameObject trophy;
    private int trophysNumber = 4;

    void Start()
    {
        InitTrophys();
    }

    private void InitTrophys()
    {
        for (int i = 0; i < trophysNumber; i++)
        {
            Vector3 position = new Vector3(Random.Range(-4.0f, 4.0f), 1f, Random.Range(-4.0f, 4.0f));
            Instantiate(trophy, position, Quaternion.identity).transform.parent = trophys.transform;
        }
    }
}
