using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    public void SliderControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f) masterMixer.SetFloat("bgmusic", -80);
        else masterMixer.SetFloat("bgmusic", sound);
    }
}
