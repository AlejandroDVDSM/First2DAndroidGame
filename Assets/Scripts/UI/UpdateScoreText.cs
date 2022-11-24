using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;

public class UpdateScoreText : MonoBehaviour
{
    [SerializeField] ScoreManager _scoreManagerScript;
    int _currentScore;

    [SerializeField] LocalizedString _localStringScore;
    [SerializeField] TextMeshProUGUI _scoreText;

    // Update is called once per frame
    void Update()
    {
        _currentScore = _scoreManagerScript.Score;
        _localStringScore.Arguments[0] = _currentScore;
        _localStringScore.RefreshString();
    }

    void OnEnable()
    {
        _localStringScore.Arguments = new object[] { _scoreManagerScript.Score };
        _localStringScore.StringChanged += UpdateText;
    }

    void OnDisable()
    {
        _localStringScore.StringChanged -= UpdateText;
    }

    void UpdateText(string value)
    {
        _scoreText.text = value;
    }
}
