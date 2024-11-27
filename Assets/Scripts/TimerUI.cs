using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // Reference to Timer UI Text
    [SerializeField] private GameObject gameOverPanel; // Reference to Game Over Panel
    [SerializeField] private QuestionManager questionManager; // Reference to the QuestionManager (or equivalent)
    [SerializeField] private XPSystem xpSystem; // Reference to XPSystem (for resetting XP)
    [SerializeField] private DifficultyAdjuster difficultyAdjuster;

    private float currentTimer; // Timer value dynamically set by DifficultyAdjuster
    private bool isTimerRunning = true; // Tracks if the timer is active

    private void Start()
    {
        gameOverPanel.SetActive(false); // Ensure Game Over panel is hidden
        if (currentTimer == 0) // Ensure the timer is initialized correctly
        {
            SetTimer(30f); // Initialize timer to 30 seconds (or get it from DifficultyAdjuster)
        }
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (currentTimer > 0)
            {
                currentTimer -= Time.deltaTime; // Decrease the timer
                UpdateTimerUI(); // Update the UI
            }
            else
            {
                // Trigger Game Over when the timer reaches 0
                isTimerRunning = false;
                currentTimer = 0; // Ensure no negative values
                UpdateTimerUI();
                TriggerGameOver();
            }
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText == null)
        {
            Debug.LogError("TimerText is not assigned in the Inspector!");
            return;
        }

        timerText.text = $"{Mathf.CeilToInt(currentTimer)}s"; // Display time rounded up
    }


    private void TriggerGameOver()
    {
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true); // Show the Game Over panel
    }

    // Restart the timer, questions, and level
    public void RestartGame()
    {
        Debug.Log("RestartGame called!");
        currentTimer = 30f; // Reset the timer (or use the starting value you want)
        isTimerRunning = true; // Restart the timer
        gameOverPanel.SetActive(false); // Hide the Game Over panel
        UpdateTimerUI(); // Update the timer display

        questionManager.ResetQuestions(); // Reset the questions to start from the beginning
        xpSystem.ResetXP(); // Reset XP to its initial value
        // Re-adjust the difficulty after resetting everything
        difficultyAdjuster.AdjustDifficulty(xpSystem.InitialLevel);
    }

    // Method to dynamically update the timer value (called by DifficultyAdjuster)
    public void SetTimer(float newTime)
    {
        currentTimer = newTime;
        isTimerRunning = true; // Restart the timer
        UpdateTimerUI();
        Debug.Log($"Timer set to: {currentTimer} seconds");
    }
}
