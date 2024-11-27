using UnityEngine;

[CreateAssetMenu(fileName = "XPConfig", menuName = "BloomBrain/XP Configuration")]
public class XPConfig : ScriptableObject
{
    public int[] levelThresholds; // XP needed for each level.
    public int xpRewardPerCorrectAnswer; // XP rewarded for correct answers.
}
