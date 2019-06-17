using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class SceneChange : MonoBehaviour
{
    private Clicker cliker = new Clicker();
    private SteamVR_Action_Boolean act;

    private string sceneName;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        act = SteamVR_Input.GetBooleanAction("GrabPinch");
    }

    void Update()
    {
        //MouseChange();
        ControllerChange();
    }

    private void MouseChange()
    {
        if (cliker.clicked() && sceneName.Equals("Start"))
            SceneManager.LoadScene("Stage1");
        else if (cliker.clicked() && sceneName.Equals("End"))
            SceneManager.LoadScene("Start");
    }

    private void ControllerChange()
    {
        if (act.GetStateUp(SteamVR_Input_Sources.RightHand) && sceneName.Equals("Start"))
            SceneManager.LoadScene("Stage1");
        else if (act.GetStateUp(SteamVR_Input_Sources.RightHand) && sceneName.Equals("End"))
            SceneManager.LoadScene("Start");
    }
}
