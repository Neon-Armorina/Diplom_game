using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_fog : MonoBehaviour
{
    public float fade_speed = 1f;

    IEnumerator Start()
    {
        SpriteRenderer image = GetComponent<SpriteRenderer>();
        Color color = image.color;

        while (color.a < 1f)
        {
            color.a += fade_speed * Time.deltaTime;
            image.color = color;
            yield return null;
        }
    }
}
