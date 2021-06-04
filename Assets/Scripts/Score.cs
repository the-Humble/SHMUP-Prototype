using System;
using UnityEngine;

public static class Score
{
    private static int score;
    public static int HighScore = 0;

    // Using action as it is a callback. Listen to event
    public static Action<int> OnAddScore;

    public static void AddScore(int amount)
    {
        // Add score
        score += amount;

        // Nullable
        if (OnAddScore != null)
        {
            // Invoke the  Event
            OnAddScore.Invoke(score);
        }

    }

    public static void ResetScore()
    {
        if (score > HighScore)
        {
            HighScore = score;
        }

        score = 0;
    }

    public static void RestartScore()
    {
        AddScore(-score);
    }
}
