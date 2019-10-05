using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Collider2D autoTurnCollider;
    public int direction = 1;

    private float horizontalMove = 0f;
    private bool jump = false;

    void Update() {

    }

    void FixedUpdate() {
        controller.Move(direction * runSpeed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (autoTurnCollider.IsTouching(collider)) {
            direction *= -1;
        }
    }
}
