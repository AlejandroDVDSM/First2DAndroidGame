using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, pauseBtn, scoreBackground;

    public void PauseGame()
    {
        scoreBackground.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        scoreBackground.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
