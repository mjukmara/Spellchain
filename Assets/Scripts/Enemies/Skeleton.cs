using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {

    public Enemy enemy;
    public EnemyMovement enemyMovement;
    public Rigidbody2D rb;
    public float range = 1f;
    public float seekPlayerRate = 1f;
    public float jumpHeight = 1.0f;
    public float smoothing = 0.2f;

    private bool dashing = false;
    private Vector3 dashToPos;

    void Start() {
        StartCoroutine(SeekPlayer());
    }

    void Update() {
        if (dashing) {
            transform.position = Vector3.Lerp(transform.position, dashToPos, smoothing);
        }
    }

    IEnumerator Attack(Player player) {
        enemyMovement.direction = (int)Mathf.Sign(player.transform.position.x - transform.position.x);
        Vector3 pos = transform.position;
        dashToPos = pos + Vector3.up * jumpHeight;
        dashing = true;
        yield return new WaitForSeconds(0.2f);
        dashToPos = player.transform.position;
        yield return new WaitForSeconds(0.2f);
        dashing = false;
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

    void OnCollisionEnter2D(Collision2D collision) {
        if (dashing == true) {
            if (collision.gameObject.tag == "Player") {
                Player player = collision.gameObject.GetComponent<Player>();
                player.TakeDamage(enemy.damage);
                dashing = false;

                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                Vector2 forceToSelf = new Vector2(Mathf.Sign(transform.position.x - collision.gameObject.transform.position.x) * 400f, 300.0f);
                this.rb.AddForce(forceToSelf);
                Vector2 forceToPlayer = new Vector2(Mathf.Sign(collision.gameObject.transform.position.x - transform.position.x) * 400f, 300.0f);
                rb.AddForce(forceToPlayer);
            }
        }
    }
}
