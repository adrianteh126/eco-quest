using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    private void Awake() {
        if (instance == null) {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else {
            // Destroy(gameObject);
        }
    }

    public void NextLevel(int targetSceneBuildIndex) {
        StartCoroutine(LoadLevel(targetSceneBuildIndex));
    }

    IEnumerator LoadLevel(int targetSceneBuildIndex) {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        // SceneManager.LoadSceneAsync(targetSceneBuildIndex);
        SceneManager.LoadSceneAsync(targetSceneBuildIndex);
        transitionAnim.SetTrigger("Start");
    }

}



