﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuidoSources : MonoBehaviour
{
    public AudioSource tallerSound;
    public AudioSource smallerSound;
    public AudioSource speedUpSound;
    public AudioSource speedDownSound;
    public AudioSource getTrophySound;
    public AudioSource bgm;

    private void Update()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        if (!bgm.isPlaying)
        {
            bgm.Play();
        }
    }
}
