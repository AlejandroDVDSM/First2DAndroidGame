using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    public int Score { get => score; }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void SubstractScore(int scoreToSubstract)
    {
        if (score - scoreToSubstract > 0)
        {
            score -= scoreToSubstract;
        } else
        {
            score = 0;
        }
    }
}
