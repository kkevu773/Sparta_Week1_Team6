using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gamePanel; // 캐릭터 창
    public card firstCard;
    public card secondCard;
    private Panel panel;
    public Text timeTxt;
    public Text endTxt;

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;

    public float totalTime = 30.0f;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        panel = gamePanel.GetComponent<Panel>();
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
    public void Matched()
    {
        if(firstCard.idx == secondCard.idx)
        {
            if(panel != null)
            {
                panel.LoadContent(firstCard.idx);
            }
            Time.timeScale = 0f;
            gamePanel.SetActive(true);
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if(cardCount == 0)
            {
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;
    }
    public void ResumeGame()
    {
        gamePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
