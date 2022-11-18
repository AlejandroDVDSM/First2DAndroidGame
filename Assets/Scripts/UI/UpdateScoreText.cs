using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScoreText : MonoBehaviour
{
    [SerializeField] ScoreManager _scoreManagerScript;
    int _currentScore;
    TextMeshProUGUI _scoreText;

    void Start()
    {
        _scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        _currentScore = _scoreManagerScript.Score;
        _scoreText.text = _currentScore + " points";
    }
}
