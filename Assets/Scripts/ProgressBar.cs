using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider progressBar; // Slider for progress bar
    [SerializeField] private XPSystem xpSystem; // Reference to the XPSystem
    [SerializeField] private XPConfig xpConfig; // Reference to the XPConfig

    private bool isLevelUp = false; // Flag to prevent Update from overwriting reset

    private void OnEnable()
    {
        // Subscribe to the OnLevelUp event
        xpSystem.OnLevelUp += ResetProgressBar;
    }

    private void OnDisable()
    {
        // Unsubscribe from the OnLevelUp event to avoid memory leaks
        xpSystem.OnLevelUp -= ResetProgressBar;
    }

    private void Update()
    {
        // Skip updating the progress bar immediately after a level-up
        if (isLevelUp) return;

        if (xpSystem.XPToNextLevel > 0) // Avoid division by zero
        {
            float progress = (float)xpSystem.CurrentXP / xpConfig.levelThresholds[xpSystem.CurrentLevel];
            progressBar.value = progress;
        }
    }

    private void ResetProgressBar(int newLevel)
    {
        // Reset the progress bar when a level-up occurs
        progressBar.value = 0.0f;
        isLevelUp = true; // Set flag to prevent Update from interfering
        Debug.Log($"Progress bar reset on Level Up! New Level: {newLevel}");

        // Delay clearing the flag to allow Update to resume
        Invoke(nameof(ClearLevelUpFlag), 0.1f); // Small delay for reset effect
    }

    private void ClearLevelUpFlag()
    {
        isLevelUp = false;
    }
}
