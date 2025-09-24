using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gamePanel;


    public card firstCard;
    public card secondCard;
    private Panel panel;
    public Text timeTxt;
    public GameObject restartbtn;

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;

    public float totalTime = 30.0f;

    private bool isGameOver = false;

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
        isGameOver = false;
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (totalTime > 0f)
            {
                totalTime -= Time.deltaTime;
            }
            else
            {
                totalTime = 0f;
                Time.timeScale = 0f;
                audioSource = null;
                isGameOver = true;
            }
        }



        timeTxt.text = totalTime.ToString("N2");
    }
    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            if (panel != null)
            {
                panel.LoadContent(firstCard.idx);
            }
            Time.timeScale = 0f;
            StartCoroutine(ShowCoroutine());
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                restartbtn.SetActive(true);
                Time.timeScale = 0.0f;
                isGameOver = true;
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
    IEnumerator ShowCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        Show();
    }
    public void Show()
    {
        gamePanel.SetActive(true);
    }
}
