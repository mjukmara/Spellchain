using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpell : Spell {
    public Rigidbody2D rb;
    public GameObject explosionPrefab;

    public override void Start() {
        base.Start();
        rb.AddForce(Vector2.up * 100f);
    }

    void Update() {

    }

    public override void OnSpellEnd() {
        base.OnSpellEnd();
        if (explosionPrefab) {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }

    public override void OnNextSpell(GameObject nextSpell, int index) {
        nextSpell.transform.Rotate(Vector3.forward * (360 / nextSpellCount * index));
        
    }
}
