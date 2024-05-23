using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordAndCoins : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text FloorText;
    public void Start()
    {
        coinText.text = "YOUR COINS: " + PlayerPrefs.GetInt("coins").ToString();
        FloorText.text = "RECORD FLOOR: " + PlayerPrefs.GetInt("MaxFloor").ToString();

        if (PlayerPrefs.GetInt("coins") == 0)
            coinText.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("MaxFloor") == 0)
            FloorText.gameObject.SetActive(false);
    }
}
