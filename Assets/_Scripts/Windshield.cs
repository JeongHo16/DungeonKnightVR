using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windshield : MonoBehaviour
{
    public Text scoreText;
    public GameObject trophys;
    //public Sprite blackImage;

    private void Start()
    {
        ShowCurrentState();
    }



    private void ShowCurrentState()
    {
        if (trophys.transform.childCount != 0)
            scoreText.text = "<b>남은 보석 수: " + trophys.transform.childCount + "</b>";
        else
            scoreText.text = "Game Clear";
    }
}
