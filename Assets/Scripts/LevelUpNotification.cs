using UnityEngine;
using TMPro;

public class LevelUpNotification : MonoBehaviour
{
    [SerializeField] private XPSystem xpSystem; // Reference to XPSystem
    [SerializeField] private GameObject levelUpPanel; // Panel for level-up notifications
    [SerializeField] private TMP_Text levelUpText; // Text component for messages

    private void OnEnable()
    {
        // Subscribe to the OnLevelUp event
        xpSystem.OnLevelUp += ShowLevelUpNotification;
    }

    private void OnDisable()
    {
        // Unsubscribe from the OnLevelUp event to avoid memory leaks
        xpSystem.OnLevelUp -= ShowLevelUpNotification;
    }

    public void ShowLevelUpNotification(int newLevel)
    {
        levelUpText.text = $"Level Up! Welcome to Level {newLevel}!";
        levelUpPanel.SetActive(true);
    }

    public void HideLevelUpNotification()
    {
        levelUpPanel.SetActive(false);
    }
}
