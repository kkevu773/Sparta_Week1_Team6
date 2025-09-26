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

    public GameObject resultobj;      // ���� UI Image (��� ǥ�ÿ�), Inspector���� ����
    public GameObject successobj;
    public GameObject loseobj;
    public Sprite successImage;    // ���� �̹���
    public Sprite loseImage;     // ���� �̹���

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;

    public float totalTime = 30.0f;
    public float playTime = 0.0f; //�÷��̽ð��� ����� ����
    public float best; // �ְ����� �ӽ÷� ������ ����

    // ǥ���� ������ ������ ����
    private static string success = "����";
    private static string failed = "����";
    private static string reNewBest = "�ְ��� ����!";
    private static string noBest = " ���� ";

    private bool isGameOver = false;
    private bool isTimeOver = false; // Ÿ�ӿ����� üũ�� bool�� ����


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
                ShowResult(false); // ���� �̹��� ǥ��

            }
        }
        // ������ ����Ǿ��� ��
        else
        {
            // Ÿ�ӿ����� �ƴҶ�
            if(!isTimeOver)
            {
                // �̹� �ְ����� ���� ��.
                if (PlayerPrefs.HasKey("bestRecord"))
                { 
                    best = PlayerPrefs.GetFloat("bestRecord", best);
                    // �ְ����� �����Ϻ��� ���� ��
                    if (best < playTime)
                    {
                        PlayerPrefs.SetFloat("bestRecord", playTime);
                        reNew.text = success;
                        currentRecord.text = playTime.ToString("N2");
                        bestRecord.text = best.ToString("N2");                
                    }
                    // �����Ϻ��� ������
                    else
                    {
                        PlayerPrefs.SetFloat("bestRecord", best);
                        PlayerPrefs.Save();
                        reNew.text = " ";
                        currentRecord.text = playTime.ToString("N2");
                        bestRecord.text = best.ToString("N2");
                    }
                }
                // ���� ��.
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
            // Ÿ�ӿ�����
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
