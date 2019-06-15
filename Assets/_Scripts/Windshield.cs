using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windshield : MonoBehaviour
{
    public InitGame initGame;

    public Slider stageTimer;
    public Slider speedTimer;
    public Slider tallerTimer;
    public Text stageText;
    public Text timeText;
    public GameObject trophys;

    private float stageTime;
    private int stageNumber;

    private void Start()
    {
        StartCoroutine("InitCount");
    }

    private IEnumerator InitCount()
    {
        BoolStates.isCount = false;
        int Count = 3;

        while (Count > 0)
        {
            stageText.text = "<b>" + Count.ToString() + "</b>";
            yield return new WaitForSeconds(1f);
            Count -= 1;
        }

        InitWindShield();
        BoolStates.isCount = true;
    }

    private void InitWindShield()
    {
        CurrentStage();
        stageTime = initGame.stageTimes[0].minute;
        StartCoroutine("StageTimer");
    }

    public IEnumerator ShowTextForShortTime(float duration, string text)
    {
        StopCoroutine("StageTimer");
        stageText.text = text;
        yield return new WaitForSeconds(duration);
        CurrentStage();
    }

    private string ConvertSecondsLikeClock(float seconds)
    {
        int minute = (int)(seconds / 60f);
        int second = (int)(seconds % 60f % 60f);

        return "<b>" + minute + ":" + second + "</b>";
    }

    public IEnumerator StageTimer()
    {
        while (stageTime > 0f)
        {
            stageTime -= Time.deltaTime;
            timeText.text = ConvertSecondsLikeClock(stageTime);
            stageTimer.value = Mathf.Lerp(0f, 1f, (initGame.stageTimes[stageNumber - 1].minute - stageTime)
                / initGame.stageTimes[stageNumber - 1].minute);
            yield return null;
        }
        timeText.text = "<b>Time Out</b>";
    }

    //private void StageTimer()
    //{
    //    if (stageTime > 0f)
    //    {
    //        stageTime -= Time.deltaTime;
    //        timeText.text = ConvertSecondsLikeClock(stageTime);
    //        stageTimer.value = Mathf.Lerp(0f, 1f, (initGame.stageTimes[stageNumber - 1].minute - stageTime)
    //            / initGame.stageTimes[stageNumber - 1].minute);
    //    }
    //    else
    //    {
    //        timeText.text = "<b>Time Out</b>";
    //    }
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

    public void CurrentStage()
    {
        stageNumber = (5 - trophys.transform.childCount);
        if (trophys.transform.childCount != 0)
            stageText.text = "<b>Stage " + stageNumber + "</b>";
        else
            stageText.text = "<b>Game Clear</b>";
    }
}
