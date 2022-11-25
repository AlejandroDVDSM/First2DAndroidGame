using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerText;
    TriggerEndgameMenu _triggerEndgameMenu;
    private float _timeInSeconds = 60;

    public float TimeInSeconds { get => _timeInSeconds; }

    void Start()
    {
        _triggerEndgameMenu = GetComponent<TriggerEndgameMenu>();
    }

    void Update()
    {
        if (_timeInSeconds > 0)
        {
            _timeInSeconds -= Time.deltaTime;
            DisplayTime(_timeInSeconds);
        }

        if (_timeInSeconds < 10) _timerText.color = Color.red;
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            _triggerEndgameMenu.Endgame();
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
