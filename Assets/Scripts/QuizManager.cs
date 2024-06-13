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
    public Message[] loseMessage;
    public Actor[] actors;

    AudioManager audioManager;
    [SerializeField]
    private BooleanSO CowCompletedSO;
    [SerializeField]
    private BooleanSO ChickenCompletedSO;
    [SerializeField]
    private BooleanSO RabbitCompletedSO;

    void Awake() {
        // audioManager = GameObject.FindGameObjectsWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start() {
        SceneController.targetSceneIndex = 1;
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
            audioManager.PlaySFX(audioManager.answerWrong);
            Heart.health -= 1;
            if (Heart.health == 0) {
                Debug.Log("You lose all your health");
                switch (SceneManager.GetActiveScene().buildIndex) {
                    case 2:
                        audioManager.PlaySFX(audioManager.cowSFX);
                        break;
                    case 3:
                        audioManager.PlaySFX(audioManager.chickenSFX);
                        break;
                    case 4:
                        audioManager.PlaySFX(audioManager.rabbitSFX);
                        break;
                    default:
                        break;
                }
                StartCoroutine(LoseGame());
                DialogManager.isActive = false;
            }
            return;
        }
        Debug.Log("Correct answer");
        audioManager.PlaySFX(audioManager.answerCorrect);
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
            switch (SceneManager.GetActiveScene().buildIndex) {
                case 2:
                    audioManager.PlaySFX(audioManager.cowSFX);
                    CowCompletedSO.Value = true;
                    break;
                case 3:
                    audioManager.PlaySFX(audioManager.chickenSFX);
                    ChickenCompletedSO.Value = true;
                    break;
                case 4:
                    audioManager.PlaySFX(audioManager.rabbitSFX);
                    RabbitCompletedSO.Value = true;
                    break;
                default:
                    break;
            }
            StartCoroutine(FinishGame());
            DialogManager.isActive = false;
        }
    }

    IEnumerator FinishGame() {
        FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
        yield return new WaitForSeconds(5);
        FindObjectOfType<SceneController>().NextLevel();
    }

    IEnumerator LoseGame() {
        FindObjectOfType<DialogManager>().OpenDialog(loseMessage, actors);
        yield return new WaitForSeconds(5);
        FindObjectOfType<SceneController>().NextLevel();
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
