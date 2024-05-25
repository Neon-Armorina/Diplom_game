using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    public float fade_speed = 1f;
    private SoundManager soundManager;
    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }


    IEnumerator Start()
    {
        soundManager.PlaySFX(soundManager.DeathSound);
        Image image = GetComponent<Image>();
        Color color = image.color;

        while(color.a < 1f)
        {
            color.a += fade_speed * Time.deltaTime;
            image.color = color;
            yield return null;
        }
    }
}
