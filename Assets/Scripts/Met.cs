using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Met : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;

    //Cached References
    Rigidbody2D myRigidBody;




    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }


    void Update() {

        // Debug.Log(transform.localScale.x);
        if (IsFacingRight() == true) {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        } else {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }

    }


    private bool IsFacingRight() {
        return transform.localScale.x > 0;
    }



    //the collider at the front of the met that determines when to turn around based on it touching the ground or triggering with megamans collider (may need to adjust this to be more specific later so that it does not flip when being shot)
    private void OnTriggerExit2D(Collider2D otherCollider) {
        //switching the localScale to -1 or 1 so that the sprite flips.
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }


}
