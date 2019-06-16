using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windshield : MonoBehaviour
{
    //public InitGame initGame;
    public PlayerController playerController;
    public AuidoSources auidoSources;

    public Slider stageTimerSlider;
    public Slider speedTimerSlider;
    public Slider tallerTimerSlider;
    public Text stageText;
    public Text timeText;

    public int[] stageTimes;

    private float stageTime;
    public int stageNumber = 1;

    private IEnumerator Start()
    {
        StartCoroutine("CountForStageStart");
        yield return new WaitForSeconds(3f);
        InitWindShield();
    }

    private IEnumerator CountForStageStart() //시작전 3, 2, 1 세는 함수
    {
        int Count = 3;
        BoolStates.isCount = true;

        while (Count > 0)
        {
            stageText.text = "<b>" + Count.ToString() + "</b>";
            yield return new WaitForSeconds(1f);
            Count -= 1;
        }

        BoolStates.isCount = false;
    }

    private void InitWindShield() //윈드쉴드 스테이지 갱신, 타이머 시작
    {
        CurrentStage();
        StartCoroutine("StageTimer");
    }

    public IEnumerator GoToTheNextStage(float duration, string text) //클리어 메시지 나타내고, 카운트 세고, InitWindShield()
    {                                                                //스테이지 4에서는 game clear
        auidoSources.getTrophySound.Play();

        StopCoroutine("StageTimer");
        timeText.text = "<b>00:00</b>";
        ResetAndStopItemCoroutine();

        BoolStates.isCount = true;

        if (stageNumber != 4) //stage 4 시작시 까지
        {
            stageNumber += 1;
            stageText.text = text;
            yield return new WaitForSeconds(duration);
            BoolStates.isCount = false;

            StartCoroutine("CountForStageStart");
            yield return new WaitForSeconds(duration);

            InitWindShield();
        }
        else
        {
            stageText.text = "<b>Game Clear</b>";
            BoolStates.isCount = false;
        }
    }

    private IEnumerator StageTimer() //스테이지별 타이머
    {
        stageTime = stageTimes[stageNumber - 1];
        float countTime = stageTime;
        while (countTime > 0f)
        {
            countTime -= Time.deltaTime;
            timeText.text = ConvertSecondsLikeClock(countTime);
            stageTimerSlider.value = Mathf.Lerp(0f, 1f, (stageTime - countTime) / stageTime);
            yield return null;
        }
        timeText.text = "<b>Time Out</b>";
    }

    private string ConvertSecondsLikeClock(float seconds) //남은 초 시계처럼 보여주기
    {
        int minute = (int)(seconds / 60f);
        int second = (int)(seconds % 60f % 60f);

        if (second > 9)
            return "<b>" + minute + ":" + second + "</b>";
        else
            return "<b>" + minute + ":0" + second + "</b>";
    }

    private void ResetAndStopItemCoroutine()
    {
        stageTimerSlider.value = 0;

        if (BoolStates.isTaller == true)
        {
            StopCoroutine("TallerTimer");
            tallerTimerSlider.value = 0;
        }

        if (BoolStates.isSpeedUp == true)
        {
            StopCoroutine("SpeedUpTimer");
            speedTimerSlider.value = 0;
        }
    }

    public void StartItemCoroutine(string itemType)
    {
        if (itemType.Equals("TallerItem"))
        {
            if (BoolStates.isTaller == false)
                StartCoroutine("TallerTimer");
            else
            {
                StopCoroutine("TallerTimer");
                StartCoroutine("TallerTimer");
            }
        }
        else
        {
            if (BoolStates.isSpeedUp == false)
                StartCoroutine("SpeedUpTimer");
            else
            {
                StopCoroutine("SpeedUpTimer");
                StartCoroutine("SpeedUpTimer");
            }
        }
    }

    public IEnumerator SpeedUpTimer()
    {
        auidoSources.speedUpSound.Play();
        BoolStates.isSpeedUp = true;
        float elaspedTime = 0f;
        float tallerTime = 60f;

        playerController.velocity = 2f;

        while (elaspedTime < tallerTime)
        {
            elaspedTime += Time.deltaTime;
            speedTimerSlider.value = Mathf.Lerp(0f, 1f, elaspedTime / tallerTime);
            yield return null;
        }

        playerController.velocity = 1f;
        elaspedTime = 0f;
        speedTimerSlider.value = 0f;
        BoolStates.isSpeedUp = false;
        auidoSources.speedDownSound.Play();
    }

    public IEnumerator TallerTimer() //키 커졌을때
    {
        auidoSources.tallerSound.Play();
        BoolStates.isTaller = true;
        float elaspedTime = 0f;
        float tallerTime = 40f;

        while (elaspedTime < tallerTime)
        {
            elaspedTime += Time.deltaTime;
            tallerTimerSlider.value = Mathf.Lerp(0f, 1f, elaspedTime / tallerTime);
            yield return null;
        }

        elaspedTime = 0f;
        tallerTimerSlider.value = 0f;

        playerController.body.transform.position = new Vector3(playerController.player.transform.position.x,
            1f, playerController.player.transform.position.z);
        BoolStates.isTaller = false;
        auidoSources.smallerSound.Play();
    }

    private void CurrentStage() //현재 스테이지 갱신
    {
        stageText.text = "<b>Stage " + stageNumber + "</b>";
    }
}
