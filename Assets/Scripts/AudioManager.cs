using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip background2;
    public AudioClip answerCorrect;
    public AudioClip answerWrong;
    public AudioClip cowSFX;
    public AudioClip chickenSFX;
    public AudioClip rabbitSFX;

    private void Start() {
        int currentStage = SceneManager.GetActiveScene().buildIndex;
        if (currentStage == 0)
            musicSource.clip = background;
        else
            musicSource.clip = background2;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }


}
