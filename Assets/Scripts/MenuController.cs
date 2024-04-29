using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            //SceneManager.LoadScene("EasyGameScene"); // Load the game scene
            SceneManager.LoadScene("GameScene"); // Load the game scene
            Time.timeScale = 1f; // Ensure time scale is set to normal
        }
        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
            SceneManager.LoadScene("MediumGameScene"); // Load the game scene
            Time.timeScale = 1f; // Ensure time scale is set to normal
        }
        if (PlayerPrefs.GetInt("Difficulty") == 3)
        {
            SceneManager.LoadScene("HardGameScene"); // Load the game scene
            Time.timeScale = 1f; // Ensure time scale is set to normal
        }
        
    }

    public void PracticeGame()
    {
        SceneManager.LoadScene("PracticeScene"); // Load the practice scene
        Time.timeScale = 1f; // Ensure time scale is set to normal
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
    public void GoToColorCustomizer()
    {
        SceneManager.LoadScene("CustomizerScene"); // Load the main menu scene
    }
    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("LeaderboardScene"); // Load the main menu scene
    }
}
