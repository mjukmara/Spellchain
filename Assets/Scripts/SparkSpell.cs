using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkSpell : Spell {

    public int damage = 30;

    public override void Start() {
        base.Start();
    }

    public override void OnSpellEnd() {
        base.OnSpellEnd();

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
