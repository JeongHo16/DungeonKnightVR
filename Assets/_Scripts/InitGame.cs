using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    public GameObject trophys;
    public GameObject[] trophy;
    public int[] stageTimes;

    void Start()
    {
        InitTrophys();
    }

    private void InitTrophys()
    {
        for (int i = 0; i < Spot.spots.Length; i++)
        {
            Vector3 position = Spot.spots[i];
            Instantiate(trophy[i], position, Quaternion.identity).transform.parent = trophys.transform;
        }
    }
}
