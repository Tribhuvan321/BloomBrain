using UnityEngine;

public class XPTest : MonoBehaviour
{
    [SerializeField] private XPSystem xpSystem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to simulate earning XP
        {
            // Use the reward value from the ScriptableObject
            int reward = xpSystem.GetXPReward();
            xpSystem.AddXP(reward);

            Debug.Log($"Gained XP: {reward}");
            Debug.Log($"Current XP: {xpSystem.CurrentXP}, Current Level: {xpSystem.CurrentLevel}, XP to Next Level: {xpSystem.XPToNextLevel}");
        }
    }
}
