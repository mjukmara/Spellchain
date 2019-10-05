using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public int maxHp = 100;
    public int hp = 100;
    public Transform greenBar;

    void Start() {
        UpdateGreenBar();
    }

    public void TakeDamage(int dmg) {
        hp -= dmg;
        if (hp < 0) {
            hp = 0;
        }
        UpdateGreenBar();
    }

    void UpdateGreenBar() {
        Vector3 scale = greenBar.localScale;
        scale.x = (float)hp / (float)maxHp;
        greenBar.localScale = scale;
    }
}
