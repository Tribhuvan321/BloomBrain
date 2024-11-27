using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyConfig", menuName = "BloomBrain/Difficulty Configuration")]
public class DifficultyConfig : ScriptableObject
{
    public DifficultySettings[] difficultySettings; // Array of settings per level
}

[System.Serializable]
public class DifficultySettings
{
    public float timeLimit; // Time limit for each level
}
