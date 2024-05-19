using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void LoadLevel()
    {
        if (PlayerPrefs.GetInt("level") == 2)
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        else
            SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
