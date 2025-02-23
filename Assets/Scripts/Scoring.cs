using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour
{
    public int score = 0; // Player's score
    public Text scoreText; // Reference to the UI Text for score display
    public PlayerHealth playerHealth; // Reference to PlayerHealth script
    public int scoreMultiplier = 1; // Default multiplier is 1

    void Start()
    {
        // Start adding 1 point every 5 seconds
        InvokeRepeating(nameof(AddScore), 5f, 5f);
    }

    void AddScore()
    {
        if (playerHealth.currentHealth > 0) // Only score when alive
        {
            score += 1 * scoreMultiplier;
            UpdateScoreText();
        }
    }

    public void AddKillPoints(int points)
    {
        if (playerHealth.currentHealth > 0)
        {
            score += points * scoreMultiplier;
            UpdateScoreText();
        }
    }

    public void ActivateMultiplier(int multiplier, float duration)
    {
        StartCoroutine(MultiplierCoroutine(multiplier, duration));
    }

    private IEnumerator MultiplierCoroutine(int multiplier, float duration)
    {
        scoreMultiplier = multiplier;
        yield return new WaitForSeconds(duration);
        scoreMultiplier = 1; 
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}