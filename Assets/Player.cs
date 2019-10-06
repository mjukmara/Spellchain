using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator animator;
    public PlayerSpells playerSpells;
    public HealthBar healthBar;
    public HealthBar cooldownBar;

    void Update() {
        cooldownBar.maxHp = (int)(playerSpells.getMaxCooldown()*100);
        cooldownBar.hp = (int)(playerSpells.getCooldown()*100);
        cooldownBar.UpdateGreenBar();
    }

    public void TakeDamage(int damage) {
        healthBar.TakeDamage(damage);
        AudioManager.PlaySfx("Hit_Hurt2");
        if (healthBar.hp == 0) {
            animator.SetBool("dead", true);
        }
    }
}
