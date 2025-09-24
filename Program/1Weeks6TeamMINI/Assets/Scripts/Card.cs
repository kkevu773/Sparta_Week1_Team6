using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"6teamMembers{idx}");
    }

    public void OpenCard()
    {
        audioSource.PlayOneShot(clip);

    }
}
