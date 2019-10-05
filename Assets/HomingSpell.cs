using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSpell : Spell {

    public float delayedActivation = 0.3f;
    public float speed = 5f;
    public float rotationSpeed = 8f;
    public int damage = 10;

    float timePassed = 0f;
    Transform targetEnemy;

    public override void Start() {
        base.Start();

        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 15f);
        foreach (Collider2D collider in hitColliders) {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance) {
                    closestDistance = distance;
                    targetEnemy = collider.gameObject.transform;
                }
            }
        }
    }

    void Update() {
        timePassed += Time.deltaTime;

        if (timePassed > delayedActivation && targetEnemy != null) {
            Vector3 offset = targetEnemy.position - transform.position;
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        Vector3 pos = transform.position;
        pos += transform.right * speed * Time.deltaTime;
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collider) {

        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
