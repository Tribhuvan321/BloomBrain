using TMPro;
using UnityEngine;

public class QuestionUI1 : MonoBehaviour
{
    [SerializeField] private QuestionManager1 questionManager;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_InputField answerInputField;

    private void Start()
    {
        questionManager.ShowNextQuestion();
    }

    public void OnSubmitAnswer()
    {
        questionManager.SubmitAnswer(answerInputField.text);
        answerInputField.text = ""; // Clear the input field
    }

    public void UpdateQuestionText(string newQuestion)
    {
        questionText.text = newQuestion;
    }
}
