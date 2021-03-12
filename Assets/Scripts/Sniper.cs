using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour {

    [SerializeField] GameObject projectile, gun;
    Animator animator;


    void Start() {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D otherCollider) {

        var megaman = otherCollider.GetComponent<Megaman>();

        if(megaman == true) {
            animator.SetBool("Attacking", true);
        }   
    }


    private void OnTriggerExit2D(Collider2D otherCollider) {

        var megaman = otherCollider.GetComponent<Megaman>();

        if(megaman == true) {
            animator.SetBool("Attacking", false); 
        }
    }


    private void OnCollisionEnter2D(Collision2D otherCollider) {
        var health = otherCollider.transform.GetComponent<Health>();
        var megaman = otherCollider.transform.GetComponent<Megaman>();

        if (megaman && health == true) { 
            health.DealDamage(14);
        }
            
    }


    public void Fire() {
        GameObject newProjectile = Instantiate(
            projectile,
            gun.transform.position,
            transform.rotation
        ) as GameObject;

        // //instantiating as a child of this parent
        // newProjectile.transform.parent = projectileParent.transform;
    }



}
