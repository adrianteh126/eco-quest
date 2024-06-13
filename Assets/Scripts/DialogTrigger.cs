using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {
    public Message[] messages;
    public Actor[] actors;
    public int targetSceneIndex;
    public void StartDialog() {
        SceneController.targetSceneIndex = targetSceneIndex;
        FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
    }
}

[System.Serializable]
public class Message {
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor {
    public string name;
    public Sprite sprite;
}