using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime
{
    public int minute;

    public StageTime(int minute)
    {
        this.minute = minute;
    }
}

public class InitGame : MonoBehaviour
{
    public GameObject trophys;
    public GameObject trophy;
    public StageTime[] stageTimes = new StageTime[4];

    void Start()
    {
        InitTrophys();
        InitStageTime();
    }

    private void InitStageTime()
    {
        for (int i = 0; i < stageTimes.Length; i++)
        {
            stageTimes[i] = new StageTime(600 - (i * 120));
            Debug.Log(stageTimes[i].minute);
        }
    }

    private void InitTrophys()
    {
        for (int i = 0; i < Spot.spots.Length; i++)
        {
            Vector3 position = Spot.spots[i];
            Instantiate(trophy, position, Quaternion.identity).transform.parent = trophys.transform;
        }
    }
}
