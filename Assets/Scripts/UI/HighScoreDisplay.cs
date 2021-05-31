using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        if (scoreText.IsActive())
        {
            SetHiScoreDisplay();
        }
    }

    private void SetHiScoreDisplay()
    {
        // Prevent Nullable scoreText
        if (scoreText == null)
        {
            return;
        }

        // Update score within the TextMeshPro Object
        this.scoreText.text = Score.HighScore.ToString();
    }
}
