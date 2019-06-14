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

    private void ShowCurrentState()
    {
        UpdateTrophy();
        UpdateHP();
    }

    private void UpdateHP()
    {
        hpText.text = "<b>X" + HP + "</b>";
    }

    private void UpdateTrophy()
    {
        if (trophys.transform.childCount != 0)
            scoreText.text = "<b>남은 보석 수: " + trophys.transform.childCount + "</b>";
        else
            scoreText.text = "Game Clear";
    }

    public void AttackedByGhost()
    {
        HP -= 1;
    }
}
