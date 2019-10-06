using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator animator;
    public HealthBar healthBar;

    public void TakeDamage(int damage) {
        healthBar.TakeDamage(damage);
        AudioManager.PlaySfx("Hit_Hurt2");
        if (healthBar.hp == 0) {
            animator.SetBool("dead", true);
        }
    }
}
