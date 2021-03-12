using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Making sure our Pickups stay gone once picked up. Since we destroy them on pickup, and they are children of this object in this script, they will not be reloaded upon death
public class ScenePersist : MonoBehaviour {

    int startingSceneIndex;

    private void Awake() {
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;

        if (numScenePersist > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start() {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    //if we go to the next level, we destroy this persistance so a new one can be created for the new pick ups on that next level
    private void Update() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex != startingSceneIndex) {
            Destroy(gameObject);
        }
    }


    
}
