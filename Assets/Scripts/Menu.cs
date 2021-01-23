using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {


    void Update() {
        StartGame();
    }


    public void StartGame() {
        if (Input.GetButtonDown("Submit") == true) {
            SceneManager.LoadScene("Level 1");
        }
    }

}
