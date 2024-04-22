using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Load the game scene
        Time.timeScale = 1f; // Ensure time scale is set to normal
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
}
