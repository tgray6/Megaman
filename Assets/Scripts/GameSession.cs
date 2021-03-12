using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    [SerializeField] int lives = 3;


    private void Awake() {
        SetUpSingleton();
    }


    private void SetUpSingleton() {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }


    //called in DamageDealer for megamans health becoming less than 0
    public void ProcessPlayerDeath() {
        if (lives > 1) {
            TakeLife();
        } else {
            ResetGameSession();
        }
    }


    private void ResetGameSession() {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }


    public void TakeLife() {
        lives = lives - 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void AddLife() {
        lives = lives + 1;
    }


    public int GetLives() {
        return lives;
    }

}
