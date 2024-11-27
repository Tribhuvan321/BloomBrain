using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private XPSystem xpSystem; // Reference to the XP system
    [SerializeField] private DifficultyAdjuster difficultyAdjuster; // Reference to the difficulty adjuster

    private void OnEnable()
    {
        // Subscribe to the level-up event
        xpSystem.OnLevelUp += HandleLevelUp;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event to avoid memory leaks
        xpSystem.OnLevelUp -= HandleLevelUp;
    }

    private void Start()
    {
        Debug.Log($"Game Start: Level {xpSystem.CurrentLevel}");
        UpdateDifficulty();
    }

    private void HandleLevelUp(int newLevel)
    {
        Debug.Log($"Level Up! Reached Level {newLevel}");
        UpdateDifficulty();
    }

    private void UpdateDifficulty()
    {
        // Update game difficulty based on the current level
        difficultyAdjuster.AdjustDifficulty(xpSystem.CurrentLevel);
    }
}
