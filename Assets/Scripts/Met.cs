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


    private void OnTriggerExit2D(Collider2D otherCollider) {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }


}
