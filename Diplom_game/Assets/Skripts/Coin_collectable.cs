using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_collectable : MonoBehaviour
{
    public int coinValue = 1;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    public void Start()
    {
        coinValue = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Character_Stats.Instance.AddCoin(coinValue);
            soundManager.PlayUISFX(soundManager.CoinPickup);
            Destroy(gameObject);
        }

    }
}
