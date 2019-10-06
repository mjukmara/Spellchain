using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperSpell : Spell {

    public override void Start() {
        base.Start();
        AudioManager.PlaySfx("Hit");
    }

    void Update() {

    }

    public override void OnNextSpell(GameObject nextSpell, int index) {
        nextSpell.transform.rotation = Quaternion.Euler(0, 0, 90);
    }
}
