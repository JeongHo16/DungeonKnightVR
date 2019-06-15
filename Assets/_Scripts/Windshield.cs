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

    private float stageTime;

    private void Start()
    {
        stageTime = 5f;
    }

    private void Update()
    {
        ShowCurrentState();
        Timer();
    }

    private void Timer()
    {
        //stageTimer.maxValue = stageTime;
        if (stageTime > 0f)
        {
            stageTime -= Time.deltaTime;
            timeText.text = "<b>" + ((Mathf.Round(stageTime * 100f)) / 100f).ToString() + "</b>";
            stageTimer.value = Mathf.Lerp(0f, stageTimer.maxValue, (5f - stageTime) / 5f);
        }
        else
        {
            timeText.text = "<b>Time Out</b>";
            //stageTimer.value = 0f;
        }
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
