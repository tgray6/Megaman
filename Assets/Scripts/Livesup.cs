using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livesup : MonoBehaviour {

    [SerializeField] AudioClip lifeupSfx;
    [SerializeField] [Range(0,1)] float lifeupVolume = 0.025f;

    //Cached component references
    AudioSource myAudioSource;
    GameSession gameSession;

    private void Start() {
        myAudioSource = GetComponent<AudioSource>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D() {
        AudioSource.PlayClipAtPoint(lifeupSfx, Camera.main.transform.position, lifeupVolume);
        gameSession.AddLife();
        Destroy(gameObject);
    }

}
