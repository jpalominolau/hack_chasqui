using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour
{
    public static Scoring Instance;
    public int score = 0;
    public Text scoreText;
    public int scoreMultiplier = 1;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        InvokeRepeating(nameof(AddScore), 5f, 5f);  // Add score every 5 seconds
    }

    void AddScore()
    {
        score += scoreMultiplier;
        UpdateScoreText();
    }

    public void AddKillPoints(int points)
    {
        score += points * scoreMultiplier;
        UpdateScoreText();
    }

    public void ActivateMultiplier(int multiplier, float duration)
    {
        StartCoroutine(MultiplierCoroutine(multiplier, duration));  // Start the multiplier coroutine
    }

    private IEnumerator MultiplierCoroutine(int multiplier, float duration)
    {
        scoreMultiplier = multiplier;  // Set the multiplier
        yield return new WaitForSeconds(duration);  // Wait for the duration
        scoreMultiplier = 1;  // Reset the multiplier
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public int GetScore()
    {
        return score;
    }
}