using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpell : Spell {
    public Rigidbody2D rb;
    public GameObject explosionPrefab;

    void Start() {
        rb.AddForce(Vector2.up * 100f);
        StartCoroutine(DelayedExplosion());
    }

    void Update() {

    }

    IEnumerator DelayedExplosion() {
        yield return new WaitForSeconds(duration);
        if (explosionPrefab) {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
