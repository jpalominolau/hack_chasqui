using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Start()
    {
        Debug.Log("StartMenu script is running!"); // Check if script is working
    }
    public void StartGame()
    {
        Debug.Log("Attempting to load MainScene...");
        SceneManager.LoadScene("MainScene"); 
    }
    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif
    }
}
