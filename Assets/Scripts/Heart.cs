using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour {
    [SerializeField]
    public static int health = 2;
    public int numOfHearts = 2;

    public Image[] hearts;
    public Sprite fullHeart;

    void Start() {
        health = 2;
    }



    // Update is called once per frame
    void Update() {
        if (health <= 0) return;

        for (int i = 0; i < hearts.Length; i++) {
            hearts[i].sprite = fullHeart;

            if (i < health) hearts[i].enabled = true;
            else hearts[i].enabled = false;

        }
    }
}
