using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Reload"))
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        }
    }
}
