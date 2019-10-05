using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpell : Spell {
    public Rigidbody2D rb;
    public GameObject explosionPrefab;
    public int damage = 25;

    public override void Start() {
        base.Start();
        rb.AddForce(Vector2.up * 100f);
        rb.AddForce(transform.right * 100f);
    }

    void Update() {

    }

    public override void OnSpellEnd() {
        base.OnSpellEnd();
        if (explosionPrefab) {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (Collider2D collider in hitColliders) {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
                    Enemy enemy = collider.gameObject.GetComponent<Enemy>();
                    if (enemy != null) {
                        enemy.TakeDamage(damage);
                    }
                }
            }
        }
    }

    public override void OnNextSpell(GameObject nextSpell, int index) {
        nextSpell.transform.Rotate(Vector3.forward * (360 / nextSpellCount * index));
        
    }
}
