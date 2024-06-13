using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public GameObject howToPlay;

    public void Start() {
        howToPlay.SetActive(false);
    }

    public void Update() {
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowHowToPlay() {
        if (howToPlay != null) {
            howToPlay.SetActive(true);
        }
        else {
            Debug.LogError("howToPlay object is not assigned!");
        }
    }


    public void BackToMenu() {
        if (howToPlay != null) {
            howToPlay.SetActive(false);
        }
        else {
            Debug.LogError("howToPlay object is not assigned!");
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
