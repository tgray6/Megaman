using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [SerializeField] float damage = 100f;

    private void OnTriggerEnter2D(Collider2D otherCollider) {

        var health = otherCollider.GetComponent<Health>();

        var megaman = otherCollider.GetComponent<Megaman>();

        if(megaman && health == true) {
            health.DealDamage(damage);
        }
        
    }

}
