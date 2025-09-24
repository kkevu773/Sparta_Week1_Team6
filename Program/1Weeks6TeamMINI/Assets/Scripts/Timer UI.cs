using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class TimerColorChanger : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        float time = gm.totalTime;
        if (time <= 10f)
        {
            gm.timeTxt.color = Color.red;
        }
        else
        {
            gm.timeTxt.color = Color.white;
        }
    }
}

