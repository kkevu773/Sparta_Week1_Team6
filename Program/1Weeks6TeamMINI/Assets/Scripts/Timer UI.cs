using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class TimerColorChanger : MonoBehaviour
{
    private GameManager gm;
    public AudioSource audioSource;
    public AudioClip tickingClip;// time_ticking_sound ���
    private bool hasPlayed = false; // ���� �ߺ� ����
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
                audioSource.PlayOneShot(tickingClip); // 10�� ������ �� time_ticking_sound �ѹ� ���
                hasPlayed = true;
            }
        }
        else
        {
            gm.timeTxt.color = Color.white;
        }
    }
}

