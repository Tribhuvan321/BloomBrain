using UnityEngine;

public class DifficultyAdjuster : MonoBehaviour
{
    [SerializeField] private XPSystem xpSystem; // Reference to XPSystem
    [SerializeField] private DifficultyConfig difficultyConfig; // ScriptableObject holding difficulty settings
    private TimerUI timerUI; // Reference to TimerUI

    private void OnEnable()
    {
        // Subscribe to OnLevelUp event in XPSystem
        xpSystem.OnLevelUp += AdjustDifficulty;
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        xpSystem.OnLevelUp -= AdjustDifficulty;
    }

    private void Start()
    {
        timerUI = FindObjectOfType<TimerUI>(); // Locate TimerUI in the scene
        AdjustDifficulty(xpSystem.CurrentLevel);
    }

    public void AdjustDifficulty(int currentLevel)
    {
        if (currentLevel < difficultyConfig.difficultySettings.Length)
        {
            DifficultySettings settings = difficultyConfig.difficultySettings[currentLevel];

            // Update the timer in TimerUI with the new time limit
            timerUI.SetTimer(settings.timeLimit);

            Debug.Log($"Difficulty Adjusted: Level {currentLevel}, Timer: {settings.timeLimit}s");
        }
        else
        {
            Debug.LogWarning("No difficulty settings for this level. Default timer values will be used.");
        }
    }
}
