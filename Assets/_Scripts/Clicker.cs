using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker
{
    public bool clicked()
    {
        return Input.anyKeyDown;
    }
}

//    {
//#if (UNITY_ANDROID || UNITY_IPHONE)
//        return Cardboard.SDK.CardboardTriggered;
//#else
//        return Input.anyKeyDown;
//#endif
//    }
