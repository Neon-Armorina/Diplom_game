using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    public float fade_speed = 1f;

    IEnumerator Start()
    {
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
