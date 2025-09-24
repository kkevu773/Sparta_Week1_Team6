using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public card firstCard;
    public card secondCard;

    public Text timeTxt;
    public Text endTxt;

    public int cardCount = 0;

    public float totalTime = 30.0f;

    AudioSource audioSource;
    public AudioClip clip;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            totalTime = 0f;
            Time.timeScale = 0f;
        }

        timeTxt.text = totalTime.ToString("N2");
    }

    // 매치 함수 아직 없어서 만들어진 이후에 매치 사운드 넣겠습니다.
}
