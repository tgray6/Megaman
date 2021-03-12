using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {


    [SerializeField] int damage = 28;
    [SerializeField] float timeToWait = 2f;

    private void OnTriggerEnter2D(Collider2D otherCollider) {

        var health = otherCollider.GetComponent<Health>();

        var megaman = otherCollider.GetComponent<CapsuleCollider2D>();


        if (megaman && health == true) {

            health.DealDamage(damage);

            if (health.GetHealth() <= 0) {
                StartCoroutine(WaitToReloadCurrentLevelOnDeath());
            }
        }
    }


    //processing player death through GameSession script and reloading current scene
    IEnumerator WaitToReloadCurrentLevelOnDeath() {
        var GameSession = FindObjectOfType<GameSession>();
        yield return new WaitForSeconds(timeToWait);
        GameSession.ProcessPlayerDeath();
    }
}
