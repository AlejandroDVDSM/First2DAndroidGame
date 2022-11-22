using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndgameMenu : MonoBehaviour
{
    [SerializeField] GameObject _endgameMenu, _score;
    AudioManager _audioManager;

    void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void Endgame()
    {
        _audioManager.Stop("GameTheme");
        Time.timeScale = 0;
        _score.SetActive(false);
        _endgameMenu.SetActive(true);
    }
}
