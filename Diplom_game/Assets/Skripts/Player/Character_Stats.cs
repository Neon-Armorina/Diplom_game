using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character_Stats : MonoBehaviour
{
    public static Character_Stats Instance;
    public TMP_Text coinText;
    public TMP_Text FloorText;

    private int floor = 0;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        coinText.text = "COINS: " + PlayerPrefs.GetInt("coins").ToString();
        FloorText.text = "FLOOR: " + floor.ToString();
    }

    public void AddCoin(int value)
    {
        int totalCoins = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", totalCoins + value);
        coinText.text = "COINS: " + PlayerPrefs.GetInt("coins").ToString();
    }

    public void AddFloor()
    {
        floor++;
        FloorText.text = "FLOOR: " + floor.ToString();
        if (PlayerPrefs.GetInt("MaxFloor") < floor) 
            PlayerPrefs.SetInt("MaxFloor", floor);
    }
}
