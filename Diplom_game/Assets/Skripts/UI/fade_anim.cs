using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade_anim : MonoBehaviour
{
    public float fade_speed = 1f;
    private Animator animator;

   

    IEnumerator Start()
    {
        Image image = GetComponent<Image>();
        animator = GetComponent<Animator>();
        Color color = image.color;

        while (color.a < 1f)
        {
            color.a += fade_speed * Time.deltaTime;
            image.color = color;
            yield return null;
        }

        animator.enabled = true;
    }
}
