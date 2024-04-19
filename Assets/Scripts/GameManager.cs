using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public Button restartButton;
    public Button quitButton;
    public Image GameOverImage;
    public TMP_Text FinalScore;
    public TMP_Text countdownText; // Text element to display countdown

    public float gameDuration = 60f; // Duration of the game in seconds
    private float timeRemaining; // Remaining time in the game
    private int score = 0;
    private bool gameOver = false;
    public bool isPracticeScene = false; // Flag to check if it's a practice scene
    

    void Start()
    {
        timeRemaining = gameDuration;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        UpdateScoreText();
        UpdateCountdownText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
     
    void UpdateCountdownText()
    {
        countdownText.text = "TIME REMAINING: " + Mathf.CeilToInt(timeRemaining).ToString();
    }

    void UpdateFinalScoreText()
    {
        FinalScore.text = "FINAL SCORE: " + score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        if (!gameOver)
        {
            score += amount;
            UpdateScoreText();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        GameOverImage.gameObject.SetActive(true);
        FinalScore.gameObject.SetActive(true);
        UpdateFinalScoreText(); 
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        Time.timeScale = 0f; 

        if (timeRemaining <= 0f)
        {
            if (isPracticeScene)
            {
                gameOverText.text = "PRACTICE SESSION COMPLETED!";
            }
            else
            {
                gameOverText.text = "LEVEL COMPLETED!";
            }
        }
    }

    void Update()
    {
        if (!gameOver)
        {
            // Update the remaining time
            timeRemaining -= Time.deltaTime;
            UpdateCountdownText();

            // Check if the game is over (time has run out)
            if (timeRemaining <= 0f)
            {
                GameOver();
            }
        }

        // Check if the game is over and the left mouse button is clicked over the RestartButton
        if (gameOver && IsPointerOverRestartButton())
        {
            RestartGame();
        }
    }

    // Check if the mouse pointer is over the RestartButton
    private bool IsPointerOverRestartButton()
    {
        // Check if the mouse pointer is over the RestartButton using EventSystem
        return restartButton != null && restartButton.IsActive() && restartButton.IsInteractable() && restartButton.GetComponent<RectTransform>().rect.Contains(Input.mousePosition);
    }

    public void RestartGame()
    {
        // Reload the currently active scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Resume normal time scale
    }

    public void RestartPractice()
    {
        // If it's a practice scene, reload the scene to restart the practice session
        if (isPracticeScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f; // Resume normal time scale
        }
    }

    public void quitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}