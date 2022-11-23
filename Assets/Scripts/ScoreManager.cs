using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int _score = 0;

    public int Score { get => _score; }

    public void AddScore(int scoreToAdd)
    {
        _score += scoreToAdd;
    }

    public void SubstractScore(int scoreToSubstract)
    {
        if (_score - scoreToSubstract > 0)
        {
            _score -= scoreToSubstract;
        } else
        {
            _score = 0;
        }
    }

    public void SetMaxScore()
    {
        PlayerPrefs.SetInt("userMaxScore", _score);
    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("userMaxScore");
    }
}
