using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windshield : MonoBehaviour
{
    public Slider stageTimer;
    public Slider speedTimer;
    public Slider tallerTimer;
    public Text stageText;
    public Text timeText;
    public GameObject trophys;

    //private int HP = 3;

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
        //UpdateHP();
    }

    //private void UpdateHP()
    //{
    //    hpText.text = "<b>X" + HP + "</b>";

    //    if (HP == 0) scoreText.text = "<b>Game Over</b>";
    //}

    public IEnumerator TallerTime()
    {
        float elaspedTime = 0f;
        float tallerTime = 3f;

        tallerTimer.value = elaspedTime;
        while (elaspedTime < tallerTime)
        {
            elaspedTime += Time.deltaTime;
            tallerTimer.value += elaspedTime;
            yield return null;
        }

        elaspedTime = 0f;
        tallerTimer.value = 0f;
    }

    private void UpdateTrophy()
    {
        if (trophys.transform.childCount != 0)
            stageText.text = "<b>Stage " + (5 - trophys.transform.childCount) + "</b>";
        else
            stageText.text = "<b>Game Clear</b>";
    }

    //public void AttackedByGhost()
    //{
    //    HP -= 1;
    //}
}
