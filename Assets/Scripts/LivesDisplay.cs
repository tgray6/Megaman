using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {

    Text livesText;
    GameSession gameSession;
    

    private void Start() {
        livesText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }


    private void Update() {
        livesText.text = gameSession.GetLives().ToString();
    }

}

