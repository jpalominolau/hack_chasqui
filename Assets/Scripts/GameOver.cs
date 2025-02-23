using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    public Text scoreText; // Reference to UI Text for displaying the score
    

    void Start()
    {
        // Retrieve the saved score from PlayerPrefs
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);  
        scoreText.text = "Score: " + playerScore.ToString();  
    }

    // Optional: Restart or exit game functions
    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("GameMenu");
    }
    

    public void ExitGame()
    {
        Application.Quit(); 
    }
}