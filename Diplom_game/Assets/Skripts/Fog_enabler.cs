using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog_enabler : MonoBehaviour
{
    public GameObject fog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fog.SetActive(true);
        }
    }
}
