using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionManager1 : MonoBehaviour
{
    [SerializeField] private XPSystem xpSystem; // Reference to the XP system
    [SerializeField] private TMP_Text questionText; // Reference to the question text UI
    private int currentQuestionIndex = 0; // Tracks the current question
    private string[] questions = {
    "What is the capital of Japan?",
    "What is the largest ocean on Earth?",
    "What is the square root of 64?",
    "Who wrote 'Romeo and Juliet'?",
    "Which planet is known as the Red Planet?",
    "What is the chemical symbol for water?",
    "Who painted the Mona Lisa?",
    "How many continents are there on Earth?",
    "What is the smallest prime number?",
    "Which country is known as the Land of the Rising Sun?"
};

    private string[] answers = {
    "Tokyo",
    "Pacific Ocean",
    "8",
    "William Shakespeare",
    "Mars",
    "H2O",
    "Leonardo da Vinci",
    "7",
    "2",
    "Japan"
};


    [SerializeField] private GameObject nextLevelButton; // Reference to the Next Level button
    [SerializeField] private string nextLevelName; // Name of the next level scene

    private void Start()
    {
        nextLevelButton.SetActive(false); // Hide the Next Level button initially
        ShowNextQuestion(); // Display the first question when the game starts
    }

    // Method to show the current question or display a completion message
    public void ShowNextQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex]; // Show the current question
            Debug.Log($"Question: {questions[currentQuestionIndex]}");
        }
        else
        {
            Debug.Log("All questions completed!");
            questionText.text = "All questions completed!";
            ShowNextLevelButton(); // Activate the Next Level button
        }
    }

    // Method to handle answer submission
    public void SubmitAnswer(string playerAnswer)
    {
        if (currentQuestionIndex < questions.Length &&
            playerAnswer.Equals(answers[currentQuestionIndex], System.StringComparison.OrdinalIgnoreCase))
        {
            xpSystem.AddXP(xpSystem.GetXPReward());
            Debug.Log("Correct Answer! XP Added.");
        }
        else
        {
            Debug.Log("Incorrect Answer.");
        }

        currentQuestionIndex++;
        ShowNextQuestion(); // Move to the next question or finish the level
    }

    // Resets the question flow to the beginning
    public void ResetQuestions()
    {
        currentQuestionIndex = 0; // Reset to the first question
        ShowNextQuestion(); // Show the first question again
    }

    // Displays the Next Level button
    private void ShowNextLevelButton()
    {
        Debug.Log("Activating Next Level Button!");
        if (nextLevelButton != null)
        {
            nextLevelButton.SetActive(true); // Show the Next Level button
        }
        else
        {
            Debug.LogWarning("Next Level Button is not assigned in the Inspector!");
        }
    }

    // Loads the next level
    public void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextLevelName))
        {
            Debug.Log($"Loading Next Level: {nextLevelName}");
            SceneManager.LoadScene(nextLevelName); // Load the next level scene
        }
        else
        {
            Debug.LogWarning("Next level name is not set!");
        }
    }
}
