using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    public Sprite soundOn;
    public Sprite soundOff;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void SwitchSound()
    {
        if (AudioListener.volume == 1f)
        {
            AudioListener.volume = 0f;
            image.sprite = soundOff;
        }
        else
        {
            AudioListener.volume = 1f;
            image.sprite = soundOn;
        }
    }
}
