using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerText;
    TriggerPauseMenu _triggerPauseMenu;
    private float _timeInSeconds = 11;

    void Start()
    {
        _triggerPauseMenu = GetComponent<TriggerPauseMenu>();
    }

    void Update()
    {
        if (_timeInSeconds > 0) _timeInSeconds -= Time.deltaTime;
        if (_timeInSeconds < 10) _timerText.color = Color.red;
        DisplayTime(_timeInSeconds);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            _triggerPauseMenu.PauseGame();
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
