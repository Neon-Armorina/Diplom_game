using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public int scene = 2;

    private void Update()
    {
        if (Input.GetButtonDown("Reload"))
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene(scene);
        }
    }

    public void NextScene()
    {
        scene++;
    }
}
