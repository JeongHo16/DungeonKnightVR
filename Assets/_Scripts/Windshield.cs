using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windshield : MonoBehaviour
{
    public Text scoreText;
    public Text hpText;
    public GameObject trophys;

    private int HP = 3;

    //public Sprite blackImage;

    private void Start()
    {

    }

    private void Update()
    {
        ShowCurrentState();
    }

    public void AttackedByGhost()
    {
        HP -= 1;
    }

    private void ShowCurrentState()
    {
        if (trophys.transform.childCount != 0)
            scoreText.text = "<b>남은 보석 수: " + trophys.transform.childCount + "</b>";
        else
            scoreText.text = "Game Clear";

        hpText.text = "<b>X" + HP + "</b>";
    }
}
