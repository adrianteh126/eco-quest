using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public GameObject HowToPlayPanel;
    public GameObject StoryPanel;

    [SerializeField]
    private BooleanSO CowCompletedSO;
    [SerializeField]
    private BooleanSO ChickenCompletedSO;
    [SerializeField]
    private BooleanSO RabbitCompletedSO;

    public void Start() {
        HowToPlayPanel.SetActive(false);
        StoryPanel.SetActive(false);
    }

    public void Update() {
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAgain() {
        CowCompletedSO.Value = false;
        ChickenCompletedSO.Value = false;
        RabbitCompletedSO.Value = false;
        SceneManager.LoadScene(1);
    }

    public void ShowHowToPlay() {
        if (HowToPlayPanel != null) {
            HowToPlayPanel.SetActive(true);
        }
        else {
            Debug.LogError("HowToPlayPanel object is not assigned!");
        }
    }

    public void ShowStory() {
        if (StoryPanel != null) {
            StoryPanel.SetActive(true);
        }
        else {
            Debug.LogError("StoryPanel object is not assigned!");
        }
    }


    public void BackToMenu() {
        if (HowToPlayPanel != null) {
            HowToPlayPanel.SetActive(false);
        }

        if (StoryPanel != null) {
            StoryPanel.SetActive(false);
        }

    }

    public void QuitGame() {
        Application.Quit();
    }
}
