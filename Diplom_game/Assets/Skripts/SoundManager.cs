using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _sfxSource;
    [SerializeField] AudioSource _UISoundSource;

    public AudioClip levelMusic;
    public AudioClip MenuMusic;
    public AudioClip PlayerJumpSound;
    public AudioClip PlayerSlideSound;
    public AudioClip PlayerStepSound;
    public AudioClip DeathSound;
    public AudioClip UISwitchButtonSound;
    public AudioClip UIPressButtonSound;
    public AudioClip CoinPickup;

    public static SoundManager Instance;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
            _musicSource.clip = MenuMusic;
        else
            _musicSource.clip = levelMusic;

        _musicSource.Play();
        
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

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu" && _musicSource.clip != levelMusic)
        {
            _musicSource.clip = levelMusic;
            _musicSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "Menu" && _musicSource.clip != MenuMusic)
        {
            _musicSource.clip = MenuMusic;
            _musicSource.Play();
        }
            
    }
    public void PlaySFX(AudioClip audioClip)
    {
        _sfxSource.clip = audioClip;
        _sfxSource.Play();
    }

    public void PlayUISFX(AudioClip audioClip)
    {
        _UISoundSource.clip = audioClip;
        _UISoundSource.Play();
    }

    public void HoverUISFX()
    { 
        _UISoundSource.PlayOneShot(UISwitchButtonSound);
    }

    public void ClickUISFX()
    {
        _UISoundSource.PlayOneShot(UIPressButtonSound);
    }

    public void StopSFX()
    {
        _sfxSource?.Stop();
    }
}
