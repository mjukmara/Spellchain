using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSpell : Spell
{
    public float speed = 5f;

    int dmg = 10;

    private float timePassed = 0;

    public override void Start()
    {
        base.Start();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos += transform.right * speed * Time.deltaTime;
        transform.position = pos;
    }

    public override void OnNextSpell(GameObject spell, int index)
    {

    }

    void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(dmg);

            Destroy(gameObject);
        }
    }
}
