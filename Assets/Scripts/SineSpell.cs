using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineSpell : Spell {

    public float speed = 5f;
    public float sineAmplitude = 1f;
    public float sineFrequency = 1f;
    int dmg = 10;

    private float timePassed = 0;

    public override void Start() {
        base.Start();

        AudioManager.PlaySfx("Randomize10");
    }

    void Update() {
        timePassed += Time.deltaTime;
        float rotate = Mathf.Sin(Mathf.PI / 2 + Time.time * sineFrequency) * sineAmplitude;
        transform.Rotate(Vector3.forward * rotate);
        Vector3 pos = transform.position;
        pos += transform.right * speed * Time.deltaTime;
        transform.position = pos;
    }

    public override void OnNextSpell(GameObject spell, int index) {

    }

    void OnCollisionEnter2D(Collision2D collider) {

        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(dmg);

            Destroy(gameObject);
        }
    }
}
