using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; // Reference to the Pause Menu Panel
    private bool isPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false); // Ensure the pause menu is hidden at the start
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            pauseMenuUI.SetActive(true); // Show the pause menu
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            pauseMenuUI.SetActive(false); // Hide the pause menu
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        pauseMenuUI.SetActive(false); // Hide the pause menu
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Resume time before loading the main menu
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your main menu scene name
    }
}
