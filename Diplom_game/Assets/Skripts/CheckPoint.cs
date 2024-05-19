using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Respawn resp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            resp.NextScene();
            PlayerPrefs.SetInt("level", 1);
            gameObject.SetActive(false);
        }

    }
}
