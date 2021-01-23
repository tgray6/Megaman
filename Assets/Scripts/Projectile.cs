using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {


    [SerializeField] float speed = 5f;


    void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D() {
        Destroy(gameObject);
    }


}
