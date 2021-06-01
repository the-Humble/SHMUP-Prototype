using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribes to action
        Score.OnAddScore += SetScoreDisplay;
    }

    private void SetScoreDisplay(int score)
    {

        // Prevent Nullable scoreText
        if (scoreText == null)
        {
            return;
        }

        // Update scoreon display
        this.scoreText.text = score.ToString();
    }

    private void OnDestroy()
    {
        // Unsuscribe to action
        Score.OnAddScore -= SetScoreDisplay;
    }
}
