using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        // Check if the "Score" key exists in PlayerPrefs
    if (PlayerPrefs.HasKey("Score"))
    {
        // If it exists, retrieve the score from PlayerPrefs
        score = PlayerPrefs.GetInt("Score");
    }
    else
    {
        // If it doesn't exist, initialize the score to 0
        score = 0;
        // Save the initial score to PlayerPrefs
        PlayerPrefs.SetInt("Score", score);
    }
        
        scoreText.text = "Coins = " + PlayerPrefs.GetInt("Score"); 
    }

    public void addScoreGold()
    {
        score = score + 5;
        scoreText.text = "Coins = " + score;

        PlayerPrefs.SetInt("Score", score);
    }
    public void addScoreSilver()
    {
        score = score + 2;
        scoreText.text = "Coins = " + score;

        PlayerPrefs.SetInt("Score", score);
    }
    public void addScoreBronze()
    {
        score = score + 1;
        scoreText.text = "Coins = " + score;
        
        PlayerPrefs.SetInt("Score", score);
    }
}
