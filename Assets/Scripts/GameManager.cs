using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    [SerializeField]
    private BooleanSO CowCompletedSO;
    [SerializeField]
    private BooleanSO ChickenCompletedSO;
    [SerializeField]
    private BooleanSO RabbitCompletedSO;

    public Image[] stars;

    public Message[] messages;
    public Actor[] actors;


    private void Awake() {
        if (instance == null) {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else {
            // Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < stars.Length; i++) stars[i].enabled = false;

        if (CowCompletedSO.Value && ChickenCompletedSO.Value && RabbitCompletedSO.Value) {
            // three starthree
            SceneController.targetSceneIndex = 0;
            FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
            for (int i = 0; i < stars.Length; i++) stars[i].enabled = true;

        }
        else if ((CowCompletedSO.Value && ChickenCompletedSO.Value) || (ChickenCompletedSO.Value && RabbitCompletedSO.Value) || (RabbitCompletedSO.Value && CowCompletedSO.Value)) {
            // two star
            for (int i = 0; i < stars.Length - 1; i++) stars[i].enabled = true;

        }
        else if (CowCompletedSO.Value || ChickenCompletedSO.Value || RabbitCompletedSO.Value) {
            // one star 
            for (int i = 0; i < stars.Length - 2; i++) stars[i].enabled = true;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
