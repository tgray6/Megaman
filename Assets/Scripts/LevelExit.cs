using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    [SerializeField] float timeToWait = 1.5f;
    // [SerializeField] float LevelExitSloMoFactor = 0.2f;


    private void OnTriggerEnter2D(Collider2D otherCollider) {

        var megaman = otherCollider.GetComponent<Megaman>();

        if(megaman == true) {
            StartCoroutine(WaitToLoadNextLevel());
        }  
    }


    IEnumerator WaitToLoadNextLevel() {
        // //slo motion effect, not used right now, can be used say, at an enemy gate for megaman or something in future/slo mo enemies/objects, etc. **Just return it to normal AFTER the yield return new WaitForSeconds()
        // timeToWait.timeScale = LevelExitSloMoFactor;
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }


    private void LoadNextScene() {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}
