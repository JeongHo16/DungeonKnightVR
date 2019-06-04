using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windshield : MonoBehaviour
{
    public Text scoreText;
    public GameObject jewels;

    void Update()
    {
        ShowCurrentState();
    }

    private void ShowCurrentState()
    {
        if (jewels.transform.childCount != 0)
            scoreText.text = "남은 보석 수: " + jewels.transform.childCount;
        else
            scoreText.text = "Game Clear";
    }
}
