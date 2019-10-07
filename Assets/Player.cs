using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator animator;
    public PlayerSpells playerSpells;
    public HealthBar healthBar;
    public HealthBar cooldownBar;
    private bool loadOnce = false;

    void Update() {
        cooldownBar.maxHp = (int)(playerSpells.getMaxCooldown()*100);
        cooldownBar.hp = (int)(playerSpells.getCooldown()*100);
        cooldownBar.UpdateGreenBar();

        if (healthBar.hp == 0) {
            if (loadOnce == false) {
                var FadeScreen = FindObjectsOfType<FadeScreen>();
                FadeScreen[0].LoadScene("Map");
                loadOnce = true;
            }
        }
    }

    public void TakeDamage(int damage) {
        healthBar.TakeDamage(damage);
        AudioManager.PlaySfx("Hit_Hurt2");
        if (healthBar.hp == 0) {
            animator.SetBool("dead", true);
        }
    }
}
