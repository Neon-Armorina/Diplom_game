using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character_death : MonoBehaviour
{
    [SerializeField] private Light _directionalLight;
    public static Character_death Instance;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text FloorText;

    public void Awake()
    {
        Instance = this;
    }

    public void Death()
    {

    }
}
