using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class TimerColorChanger : MonoBehaviour
{
    private GameManager gm;
    public AudioSource audioSource;
    public AudioClip tickingClip;// time_ticking_sound 재생
    private bool hasPlayed = false; // 사운드 중복 방지
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
        float time = gm.totalTime;
        if (time <= 10f)
        {
            gm.timeTxt.color = Color.red;
            if(!hasPlayed)
            {
                audioSource.PlayOneShot(tickingClip); // 10초 남았을 때 time_ticking_sound 한번 재생
                hasPlayed = true;
            }
        }
        else
        {
            gm.timeTxt.color = Color.white;
        }
    }
}

