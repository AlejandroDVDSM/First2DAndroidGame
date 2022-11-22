using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerText;

    private float _timeInSeconds = 3;

    void Update()
    {

        if (_timeInSeconds > 0) _timeInSeconds -= Time.deltaTime;

        DisplayTime(_timeInSeconds);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0) timeToDisplay = 0;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
