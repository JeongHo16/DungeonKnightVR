using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windshield : MonoBehaviour
{
    public Slider tallerSlider;
    public Text scoreText;
    //public Text hpText;
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

        tallerSlider.value = elaspedTime;
        while (elaspedTime < tallerTime)
        {
            elaspedTime += Time.deltaTime;
            tallerSlider.value += elaspedTime;
            yield return null;
        }

        elaspedTime = 0f;
        tallerSlider.value = 0f;
    }

    private void UpdateTrophy()
    {
        if (trophys.transform.childCount != 0)
            scoreText.text = "<b>남은 보석 수: " + trophys.transform.childCount + "</b>";
        else
            scoreText.text = "<b>Game Clear</b>";
    }

    public void AttackedByGhost()
    {
        HP -= 1;
    }
}
