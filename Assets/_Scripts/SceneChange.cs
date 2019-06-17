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
        //Debug.Log(SceneManager.GetActiveScene().name);
        act = SteamVR_Input.GetBooleanAction("GrabPinch");
    }

    void Update()
    {
        //if (act.GetStateUp(SteamVR_Input_Sources.RightHand))
        if (cliker.clicked() && sceneName.Equals("Start"))
        {
            SceneManager.LoadScene("End");
        }
        else if (cliker.clicked() && sceneName.Equals("End"))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
