using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gamePanel;


    public card firstCard;
    public card secondCard;
    private Panel panel;
    public Text timeTxt;
    public GameObject restartbtn;
    public GameObject recordWindow;
    public Text currentRecord;
    public Text bestRecord;
    public Text reNew;

    public GameObject resultobj;      // 씬의 UI Image (결과 표시용), Inspector에서 연결
    public GameObject successobj;
    public GameObject loseobj;
    public Sprite successImage;    // 성공 이미지
    public Sprite loseImage;     // 실패 이미지

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;

    public float totalTime = 30.0f;
    public float playTime = 0.0f; //플레이시간을 기록할 변수
    public float best; // 최고기록을 임시로 보존할 변수

    // 표시할 문구를 정수로 지정
    private static string success = "성공";
    private static string failed = "실패";
    private static string reNewBest = "최고기록 갱신!";
    private static string noBest = " 없음 ";

    private bool isGameOver = false;
    private bool isTimeOver = false; // 타임오버를 체크할 bool형 변수


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
                playTime += Time.deltaTime;
            }
            else
            {
                reNew.text = success;
                currentRecord.text = playTime.ToString("N2");
                bestRecord.text = best.ToString("N2");
                Invokere();
                //Invoke("Invokere", 0.5f);
                totalTime = 0f;
                restartbtn.SetActive(true);
                Time.timeScale = 0f;
                audioSource = null;
                isGameOver = true;
                isTimeOver = true;
                ShowResult(false); // 실패 이미지 표시

            }
        }
        // 게임이 종료되었을 때
        else
        {
            // 타임오버가 아닐때
            if(!isTimeOver)
            {
                // 이미 최고기록이 있을 때.
                if (PlayerPrefs.HasKey("bestRecord"))
                { 
                    best = PlayerPrefs.GetFloat("bestRecord", best);
                    // 최고기록이 현재기록보다 빠를 때
                    if (best < playTime)
                    {
                        PlayerPrefs.SetFloat("bestRecord", playTime);
                        reNew.text = success;
                        currentRecord.text = playTime.ToString("N2");
                        bestRecord.text = best.ToString("N2");                
                    }
                    // 현재기록보다 느릴때
                    else
                    {
                        PlayerPrefs.SetFloat("bestRecord", best);
                        PlayerPrefs.Save();
                        reNew.text = " ";
                        currentRecord.text = playTime.ToString("N2");
                        bestRecord.text = best.ToString("N2");
                    }
                }
                // 없을 때.
                else
                {
                    reNew.text = reNewBest;
                    PlayerPrefs.SetFloat("bestRecord", playTime);
                    PlayerPrefs.Save();
                    best = playTime;
                    currentRecord.text = playTime.ToString("N2");
                    bestRecord.text = best.ToString("N2");
                }

                
            }
            // 타임오버시
            else
            {
                reNew.text = failed;
                if (PlayerPrefs.HasKey("bestRecord"))
                {
                    PlayerPrefs.GetFloat("bestRecord", best);
                    currentRecord.text = failed;
                    bestRecord.text = best.ToString("N2");
                }
                else
                {
                    currentRecord.text = failed;
                    bestRecord.text = noBest;
                }
            }

            Invoke("Invokere", 0.5f);
        }



            timeTxt.text = totalTime.ToString("N2");
    }

    public void ShowResult(bool isSuccess)
    {
        if (isSuccess)
        {
            resultobj.SetActive(true);
            successobj.SetActive(true);
            loseobj.SetActive(false);
        }
        else
        {
            resultobj.SetActive(true);
            successobj.SetActive(false);
            loseobj.SetActive(true);
        }
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
            StartCoroutine(ShowCoroutine());
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if(cardCount == 0)
            {
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

    void Invokere()
    {
        restartbtn.SetActive(true);
        recordWindow.SetActive(true);
        ShowResult(true);
    }
}
