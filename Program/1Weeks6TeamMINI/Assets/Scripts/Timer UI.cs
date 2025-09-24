using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text timeTxt;
    public float time = 30f;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (time <= 10.0f)
        {
            timeTxt.color = Color.red;
        }
        else
        {
            timeTxt.color = Color.white;
        }
    }

    
}
