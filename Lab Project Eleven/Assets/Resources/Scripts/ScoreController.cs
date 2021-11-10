using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateScoreText();
    }

    private void updateScoreText()
    {
        scoreText.text = "Score: " + totalScore;
    }

    public void incrementScore()
    {
        totalScore++;
        updateScoreText();
    }
}
