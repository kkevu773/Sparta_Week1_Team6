using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip clip;
<<<<<<< HEAD
    // Start is called before the first frame update
=======

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
>>>>>>> New-Dev_1
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = this.clip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
