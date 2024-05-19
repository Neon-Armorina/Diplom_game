using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool PauseGame;
    public GameObject PauseGameMenu;

    private void Update()
    {
        if (Input.GetButtonDown("Escape") || Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
                Resume();
            else
                Pause();
        }      
    }

    public void Pause()
    {
        PauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void Resume()
    {
        PauseGameMenu.SetActive(false);
        Time.timeScale = 1.0f;
        PauseGame = false;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
