using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Windshield : MonoBehaviour
{
    public PlayerController playerController;
    public AuidoSources auidoSources;

    public Slider stageTimerSlider;
    public Slider speedTimerSlider;
    public Slider tallerTimerSlider;
    public Text stageText;
    public Text timeText;

    public int[] stageTimes;

    private float stageTime;

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

    private void LoadScene()
    {
        if (playerController.sceneName == "Stage1")
            SceneManager.LoadScene("Stage2");
        else if (playerController.sceneName == "Stage2")
            SceneManager.LoadScene("Stage3");
        else if (playerController.sceneName == "Stage3")
            SceneManager.LoadScene("Stage4");
        else if (playerController.sceneName == "Stage4")
            SceneManager.LoadScene("End");
    }

    public IEnumerator GoToTheNextStage(float duration) //클리어 메시지 나타내고, 카운트 세고, InitWindShield()
    {                                                                //스테이지 4에서는 game clear
        auidoSources.getTrophySound.Play();

        StopCoroutine("StageTimer");
        timeText.text = "<b>00:00</b>";
        ResetAndStopItemCoroutine();

        stageText.text = "<b>Stage Clear</b>";
        yield return new WaitForSeconds(duration);

        LoadScene();
    }

    private int GetStageNumber()
    {
        if (playerController.sceneName == "Stage1")
            return 0;
        else if (playerController.sceneName == "Stage2")
            return 1;
        else if (playerController.sceneName == "Stage3")
            return 2;
        else if (playerController.sceneName == "Stage4")
            return 3;
        else
            return 0;

    }

    private IEnumerator StageTimer() //스테이지별 타이머
    {
        stageTime = stageTimes[GetStageNumber()];
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

    private IEnumerator SpeedUpTimer()
    {
        auidoSources.speedUpSound.Play();
        BoolStates.isSpeedUp = true;
        float elaspedTime = 0f;
        float speedUpTime = 30f;

        playerController.velocity = 4f;

        while (elaspedTime < speedUpTime)
        {
            elaspedTime += Time.deltaTime;
            speedTimerSlider.value = Mathf.Lerp(0f, 1f, elaspedTime / speedUpTime);
            yield return null;
        }

        playerController.velocity = 2f;
        elaspedTime = 0f;
        speedTimerSlider.value = 0f;

        BoolStates.isSpeedUp = false;
        auidoSources.speedDownSound.Play();
    }

    private IEnumerator TallerTimer() //키 커졌을때
    {
        auidoSources.tallerSound.Play();
        BoolStates.isTaller = true;
        float elaspedTime = 0f;
        float tallerTime = 10f;

        while (elaspedTime < tallerTime)
        {
            elaspedTime += Time.deltaTime;
            tallerTimerSlider.value = Mathf.Lerp(0f, 1f, elaspedTime / tallerTime);
            yield return null;
        }

        elaspedTime = 0f;
        tallerTimerSlider.value = 0f;

        playerController.body.transform.position = new Vector3(playerController.player.transform.position.x,
            1.5f, playerController.player.transform.position.z);
        BoolStates.isTaller = false;
        auidoSources.smallerSound.Play();
    }

    private void CurrentStage() //현재 스테이지 갱신
    {
        stageText.text = "<b>" + SceneManager.GetActiveScene().name + "</b>";
    }
}
