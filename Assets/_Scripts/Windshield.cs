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

    private IEnumerator Start()
    {
        StartCoroutine("CountForStageStart");
        yield return new WaitForSeconds(3f);
        InitWindShield();
    }

    private IEnumerator CountForStageStart()
    {
        int Count = 3;
        BoolStates.isCount = false;

        while (Count > 0)
        {
            stageText.text = "<b>" + Count.ToString() + "</b>";
            yield return new WaitForSeconds(1f);
            Count -= 1;
        }

        //InitWindShield();
        BoolStates.isCount = true;
    }

    private void InitWindShield()
    {
        CurrentStage();
        StartCoroutine("StageTimer");
    }

    public IEnumerator GoToTheNextStage(float duration, string text)
    {
        StopCoroutine("StageTimer");
        BoolStates.isCount = false;

        if (stageNumber != 4)
        {
            stageText.text = text;
            yield return new WaitForSeconds(duration);
            BoolStates.isCount = true;

            StartCoroutine("CountForStageStart");
            yield return new WaitForSeconds(duration);

            CurrentStage();
            StartCoroutine("StageTimer");
        }
        else
        {
            stageText.text = "<b>Game Clear</b>";
            BoolStates.isCount = true;
        }
    }

    private string ConvertSecondsLikeClock(float seconds)
    {
        int minute = (int)(seconds / 60f);
        int second = (int)(seconds % 60f % 60f);

        return "<b>" + minute + ":" + second + "</b>";
    }

    private IEnumerator StageTimer()
    {
        //stageTime = initGame.stageTimes[stageNumber - 1].minute;
        stageTime = initGame.stageTimes[stageNumber - 1];
        while (stageTime > 0f)
        {
            stageTime -= Time.deltaTime;
            timeText.text = ConvertSecondsLikeClock(stageTime);
            stageTimer.value = Mathf.Lerp(0f, 1f, (initGame.stageTimes[stageNumber - 1] - stageTime)
                / initGame.stageTimes[stageNumber - 1]);
            yield return null;
        }
        timeText.text = "<b>Time Out</b>";
    }

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

    private void CurrentStage()
    {
        stageNumber = (5 - trophys.transform.childCount);
        if (trophys.transform.childCount != 0)
            stageText.text = "<b>Stage " + stageNumber + "</b>";
    }
}
