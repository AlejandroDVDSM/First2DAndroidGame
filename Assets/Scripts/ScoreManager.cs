using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    public int Score { get => score; }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public void SubstractScore(int pointsToSubstract)
    {
        if (score > 0) score -= pointsToSubstract;
    }
}
