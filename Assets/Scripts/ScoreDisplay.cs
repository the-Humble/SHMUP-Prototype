using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private bool finalScore;

    private GameManager gManager;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribes to action
        Score.OnAddScore += SetScoreDisplay;
        gManager = FindObjectOfType<GameManager>();
    }

    private void SetScoreDisplay(int score)
    {

        // Prevent Nullable scoreText
        if (scoreText == null)
        {
            return;
        }

        // Update scoreon display
        if(!finalScore)
        {
            // Check if the text is not for the game over or victory screen
            this.scoreText.text = score.ToString();
            return;
        }

        this.scoreText.text = score.ToString();
    }

    private void OnDestroy()
    {
        // Unsuscribe to action
        Score.OnAddScore -= SetScoreDisplay;
    }
}
