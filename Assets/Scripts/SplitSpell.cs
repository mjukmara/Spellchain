using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitSpell : Spell
{
    public float angle = 20;

    void Update() {
        Vector3 pos = transform.position;
        pos += transform.right * Time.deltaTime;
        transform.position = pos;
    }

    public override void OnNextSpell(GameObject spell, int index) {
        float offAngle = angle * (index * 2 - 1);
        spell.transform.Rotate(Vector3.forward * offAngle);
    }
}
