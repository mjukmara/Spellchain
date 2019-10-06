using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    public int damage = 30;

    public void TakeDamage(int dmg) {
        healthBar.TakeDamage(dmg);
        if (healthBar.hp == 0) {
            Destroy(gameObject);
        }
    }
}
