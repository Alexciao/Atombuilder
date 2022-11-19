using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject endScreen;
    [SerializeField] private CanvasGroup endScreenCanvasGroup;
    [Space] 
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI streakText;
    [Header("End Screen")]
    [SerializeField] private TextMeshProUGUI highScoreText;

    [Header("Public Variables")] 
    public int score = 0;
    public int highScore = 0;
    public int streak = 0;

    void Start()
    {
        endScreen.SetActive(false);
        endScreenCanvasGroup.alpha = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        UpdateText();
    }
    
    public void Increase()
    {
        streak++;
        score += streak;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    public void Decrease()
    {
        streak = 0;
        if (score <= 0)
        {
            Debug.Log("User reached less than 0 points, dying");
            Die();
        }
        else
        {
            Debug.Log("User is free to continue");
            score--;
        }
    }

    public void Die()
    {
        endScreen.SetActive(true);
        endScreenCanvasGroup.LeanAlpha(1, 0.2f);
    }

    void UpdateText()
    {
        highScoreText.text = highScore.ToString();
        scoreText.text = score.ToString();
        streakText.text = streak.ToString();
    }
}
