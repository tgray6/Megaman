using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [Header("Health Stats")]
    [SerializeField] float health = 100;
    [SerializeField] GameObject deathFX;
    [SerializeField] float durationOfDeathFX = 2f;


    public void DealDamage(float damage) {
        health -= damage;

        if(health <= 0) {
            TriggerDeathFX();
            Destroy(gameObject);
        }
    }


    private void TriggerDeathFX() {
        if (!deathFX) { return; }
        GameObject deathFXObject = Instantiate(
            deathFX,
            transform.position,
            transform.rotation) as GameObject;

            Destroy(deathFXObject, durationOfDeathFX);
    }

}
