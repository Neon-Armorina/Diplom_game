using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class fade_text : MonoBehaviour
{
    public float fade_speed = 1f;

    IEnumerator Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();
        Color color = text.color;

        while (color.a < 1f)
        {
            color.a += fade_speed * Time.deltaTime;
            text.color = color;
            yield return null;
        }
    }
}
