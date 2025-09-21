using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Needed to reload scene

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text scoreCountText;
    private int score = 0;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreCountText.text = $"Score {score}";
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pause game

        // Show and unlock cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Retry()
    {
        Time.timeScale = 1f; // Resume game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene

        // Optional: hide cursor again if the game auto-hides it
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}

