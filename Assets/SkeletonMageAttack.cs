using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMageAttack : MonoBehaviour {

    public int damage = 40;
    public Transform targetPos;
    public Vector3 startPos;
    public Vector3 endPos;
    public float speed = 1f;
    public float timePassed = 0;
    public bool inited = false;

    void Start() {
        startPos = transform.position;
        endPos = targetPos.position;
    }

    void Update() {
        if (inited) {
            timePassed += Time.deltaTime;
            float interpTime = Mathf.Clamp(timePassed*speed, 0, 1);

            Vector3 newPos = Vector3.Lerp(startPos, endPos, interpTime);
            newPos.y += Mathf.Sin(interpTime * Mathf.PI);
            transform.position = newPos;

            if (interpTime >= 1f) {
                DestroySelf();
            }
        }
    }

    public void SetTargetPos(Vector3 pos) {
        targetPos.position = pos;
        startPos = transform.position;
        endPos = targetPos.position;
        inited = true;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 forceToPlayer = new Vector2(Mathf.Sign(collision.gameObject.transform.position.x - transform.position.x) * 400f, 300.0f);
            rb.AddForce(forceToPlayer);
        }
        DestroySelf();
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}
