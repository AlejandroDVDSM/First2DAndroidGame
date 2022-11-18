using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu, _pauseBtn, _scoreBackground;

    public void PauseGame()
    {
        _scoreBackground.SetActive(false);
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _scoreBackground.SetActive(true);
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
