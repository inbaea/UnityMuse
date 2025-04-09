using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OXManager : MonoBehaviour
{
    public QuestionData questionData;

    public TMP_Text questionText;
    public TMP_Text scoreText;
    public TMP_Text topicText;
    public Button oButton;
    public Button xButton;

    private int score = 0;
    private List<QuestionData.Question> questions;
    private QuestionData.Question currentQuestion;

    void Start()
    {
        questions = new List<QuestionData.Question>(questionData.questions); // ����
        scoreText.text = "����: 0";

        oButton.onClick.AddListener(() => CheckAnswer(true));
        xButton.onClick.AddListener(() => CheckAnswer(false));

        NextQuestion();
    }

    void NextQuestion()
    {
        if (questions.Count > 0)
        {
            int randomIndex = Random.Range(0, questions.Count);
            currentQuestion = questions[randomIndex];
            questionText.text = currentQuestion.questionText;
            topicText.text = currentQuestion.topic;
        }
        else
        {
            questionText.text = "���� ����!";
            topicText.text = "";
            oButton.interactable = false;
            xButton.interactable = false;
        }
    }

    void CheckAnswer(bool playerChoice)
    {
        if (playerChoice == currentQuestion.isCorrect)
        {
            score += 10;
            scoreText.text = "����: " + score;
        }

        questions.Remove(currentQuestion);
        NextQuestion();
    }
}
