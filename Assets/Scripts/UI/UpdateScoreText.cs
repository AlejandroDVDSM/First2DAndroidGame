using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScoreText : MonoBehaviour
{
    [SerializeField] GameObject scoreManagerGameObject;
    ScoreManager scoreManagerScript;
    int currentScore;
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        scoreManagerScript = scoreManagerGameObject.GetComponent<ScoreManager>();
    }


    // Update is called once per frame
    void Update()
    {
        currentScore = scoreManagerScript.Score;
        scoreText.text = currentScore + " points";
    }
}
