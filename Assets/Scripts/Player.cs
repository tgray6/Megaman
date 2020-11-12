using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Config
    [SerializeField] float moveSpeed = 2.5f;
    [SerializeField] float jumpSpeed = 6f;
    [SerializeField] float climbSpeed = 2f;

    // // State
    // bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;




    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }



    void Update() {
        Run();
        Jump();
        ClimbLadder();
        FlipSprite();
    }



    private void Run() {

        var deltaX = Input.GetAxis("Horizontal"); //value is between -1 to +1

        Vector2 playerVelocity = new Vector2(deltaX * moveSpeed, myRigidBody.velocity.y);

        // Debug.Log(playerVelocity); //this is returning - speed for left and positive speed for right

        myRigidBody.velocity = playerVelocity;

        UpdateRunAnimation();
    }


    private void ClimbLadder() {

        //if megamans collider is NOT colliding with the climbing layer, which all ladders are designated, which we find through IsTouchingLayers built in method, then we won't enable climbing, otherwise, enable climbing
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")) == false) {
            myAnimator.SetBool("Climbing", false);
            myRigidBody.gravityScale = gravityScaleAtStart;
            return;
        } 

        var deltaY = Input.GetAxis("Vertical"); //value is between -1 to +1

        Vector2 playerClimbVelocity = new Vector2(myRigidBody.velocity.x, deltaY * climbSpeed);
            
        myRigidBody.velocity = playerClimbVelocity;

        myRigidBody.gravityScale = 0f;
        
        UpdateClimbAnimation(); 
    }


    private void Jump() {

        //if megamans collider is NOT colliding with the ground layer, which we find through IsTouchingLayers built in method, then we won't enable jumping, otherwise, enable jump
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) == false) {
            myAnimator.SetBool("Jumping", true);
            return;
        }

        myAnimator.SetBool("Jumping", false);

        if (Input.GetButtonDown("Jump") == true) {
            Vector2 jumpVelocityToAdd = new Vector2(myRigidBody.velocity.x, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }


    private void FlipSprite() {
        //if player is moving horizontally, reverse the current scaling on the x axis. this is saying IF we are moving, then this bool MUST be true
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        //our scaling becomes +1 or -1 depending on the SIGN of the movement, so we are setting it to -1 if we are moving left or +1 if we are moving right, without needing an else statement, keeping our Y scaling at 1f, the norm
        if (playerHasHorizontalSpeed == true) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        } 
    }


    //used the same bool as in flip sprite above to check for movement, if so, toggle the animation parameter
    private void UpdateRunAnimation() {

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon; 

        if (playerHasHorizontalSpeed == true) {
            myAnimator.SetBool("Running", true);
        } else {
            myAnimator.SetBool("Running", false);
        }
    }


    private void UpdateClimbAnimation() {

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon; 

        if (playerHasVerticalSpeed == true) {
            myAnimator.SetBool("Climbing", true);
        } else {
            myAnimator.SetBool("Climbing", false);
        }
    }


}
