using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour {
    public Question[] questions;
    public TextMeshProUGUI currentQuestionNumber;

    public TextMeshProUGUI[] options;
    public int currentQuestion;
    public TextMeshProUGUI questionDescription;

    public Message[] messages;
    public Actor[] actors;


    void Start() {
        UpdateQuestion();
    }

    private void UpdateQuestion() {
        currentQuestionNumber.text = (currentQuestion + 1).ToString();
        questionDescription.text = questions[currentQuestion].questionDescription;
        for (int i = 0; i < options.Length; i++) {
            options[i].text = questions[currentQuestion].answers[i].answerDescription;
        }
    }

    public void BtnClicked(int index) {
        if (questions[currentQuestion].correctAnswerIndex != index) {
            // handle wrong answer
            Debug.Log("Wrong answer");
            return;
        }
        Debug.Log("Correct answer");
        // handle correct answer
        NextQuestion();
    }

    public void NextQuestion() {
        currentQuestion++;
        if (currentQuestion < questions.Length) {
            UpdateQuestion();
        }
        else {
            Debug.Log("Question End");
            StartCoroutine(FinishGame());
            DialogManager.isActive = false;
        }
    }

    IEnumerator FinishGame() {
        FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
        yield return new WaitForSeconds(5);
        FindObjectOfType<SceneController>().NextLevel(0);
    }
}

[System.Serializable]
public class Question {
    public string questionDescription;

    public Answer[] answers = new Answer[4];
    public int correctAnswerIndex;

}

[System.Serializable]
public class Answer {
    public string answerDescription;
}
