using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndgameMenu : MonoBehaviour
{
    [SerializeField] GameObject _endgameMenu, _score, _shareScoreBtn, _recordMessage;
    AudioManager _audioManager;
    [SerializeField] ScoreManager _scoreManager;

    void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }


    public void Endgame()
    {
        _audioManager.Stop("GameTheme");
        _audioManager.Play("MainMenuTheme");
        Time.timeScale = 0;
        _score.SetActive(false);
        _endgameMenu.SetActive(true);

        var currentScore = _scoreManager.Score;
        if (currentScore > _scoreManager.GetMaxScore())
        {
            _scoreManager.SetMaxScore();
            EnableShareScoreBtn();
        }
    }

    void EnableShareScoreBtn()
    {
        _recordMessage.SetActive(false);
        _shareScoreBtn.SetActive(true);
    }
}
