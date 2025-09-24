using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;
    public Animator anim;

    public SpriteRenderer frontImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"6teamMe{idx}");
    }
    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
    }
    void OnMouseDown()
    {
        OpenCard();
    }
    public void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }
    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }
}
