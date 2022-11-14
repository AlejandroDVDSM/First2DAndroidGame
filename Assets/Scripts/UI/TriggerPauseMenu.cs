using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, pauseBtn;

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseBtn.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseBtn.SetActive(true);
        Time.timeScale = 1;
    }
}
