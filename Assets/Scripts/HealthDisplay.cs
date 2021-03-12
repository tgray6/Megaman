using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    [SerializeField] Sprite[] images;
    Image image;
    Megaman megaman;
    Health health;

    
    private void Awake() {
        megaman = FindObjectOfType<Megaman>();
    }


    private void Start() {
        health = megaman.GetComponent<Health>();
        image = GetComponent<Image>();
    }


    private void Update() {
        if (health.GetHealth() <= 0 ){
            image.sprite = images[0];
        } else {
            image.sprite = images[(int)health.GetHealth()];
        }
    }



    
}
