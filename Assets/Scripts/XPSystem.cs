using System;
using UnityEngine;

public class XPSystem : MonoBehaviour
{
    [SerializeField] private XPConfig xpConfig; // Reference to the ScriptableObject
    private int currentXP = 0;
    private int currentLevel = 0;
    private int initialXP = 0; // Store initial XP value
    private int initialLevel = 0;

    // Event to notify when a level-up occurs
    public event Action<int> OnLevelUp;

    // Getter methods for UI and other systems  
    public int CurrentXP => currentXP;
    public int CurrentLevel => currentLevel;
    public int InitialLevel => initialLevel;
    public int XPToNextLevel => currentLevel < xpConfig.levelThresholds.Length
        ? xpConfig.levelThresholds[currentLevel] - currentXP
        : 0; // 0 if max level reached

    private void Start()
    {
        initialXP = currentXP; // Store the initial XP value
        initialLevel = currentLevel;
    }

    // Call this method when the player earns XP
    public void AddXP(int amount)
    {
        currentXP += amount;
        CheckForLevelUp();
    }

    // Reset XP to the initial value (called on game restart)
    public void ResetXP()
    {
        currentXP = initialXP; // Reset XP to initial value
        Debug.Log($"XP reset to {currentXP}");
    }

    private void CheckForLevelUp()
    {
        if (currentLevel < xpConfig.levelThresholds.Length &&
            currentXP >= xpConfig.levelThresholds[currentLevel])
        {
            currentLevel++;
            Debug.Log($"Level Up Triggered: Current Level = {currentLevel}");
            OnLevelUp?.Invoke(currentLevel); // Fire the event
        }
    }

    public int GetXPReward()
    {
        return xpConfig.xpRewardPerCorrectAnswer;
    }

}
