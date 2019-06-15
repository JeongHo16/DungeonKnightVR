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
            Vector3 position = Spot.spots[i];
            Instantiate(trophy, position, Quaternion.identity).transform.parent = trophys.transform;
        }
    }
}
