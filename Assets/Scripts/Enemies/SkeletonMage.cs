﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMage : MonoBehaviour {

    public EnemyMovement enemyMovement;
    public GameObject attackPrefab;
    public Transform attackPoint;

    public float range = 3f;
    public float seekPlayerRate = 1f;

    private bool attacking = false;

    void Start() {
        StartCoroutine(SeekPlayer());
    }

    void Update() {

    }

    IEnumerator Attack(Player player) {
        enemyMovement.direction = (int)Mathf.Sign(player.transform.position.x - transform.position.x);
        Vector3 pos = transform.position;
        attacking = true;
        yield return new WaitForSeconds(0.1f);
        int oldDirection = enemyMovement.direction;
        enemyMovement.direction = 0;
        GameObject attack = Instantiate(attackPrefab, attackPoint.position, Quaternion.identity);
        SkeletonMageAttack attackScript = attack.GetComponent<SkeletonMageAttack>();
        attackScript.SetTargetPos(player.transform.position);
        yield return new WaitForSeconds(0.5f);
        attacking = false;
        enemyMovement.direction = oldDirection;
    }

    IEnumerator SeekPlayer() {
        while (true) {
            yield return new WaitForSeconds(1.0f / seekPlayerRate);
            List<Collider2D> colliders = FindNearbyCollidersByLayer(range, "Player");

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length > 0) {
                GameObject playerGo = players[0];
                Player player = playerGo.GetComponent<Player>();
                float distance = Vector3.Distance(transform.position, playerGo.transform.position);
                if (distance < range) {
                    StartCoroutine(Attack(player));
                }
            }
        }
    }

    List<Collider2D> FindNearbyCollidersByLayer(float range, string layer) {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);
        List<Collider2D> foundColliders = new List<Collider2D>();
        foreach (Collider2D collider in hitColliders) {
            if (collider.gameObject.layer == LayerMask.NameToLayer(layer)) {
                foundColliders.Add(collider);
            }
        }
        return foundColliders;
    }
}
