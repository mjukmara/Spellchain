using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitSpell : Spell
{
    public int splitCount = 2;
    public float angle = 20;

    public override void OnNextSpell(GameObject nextSpell, int index) {
        Debug.Log("Split, index: " + index);
        nextSpellCount = splitCount;
        float offAngle = angle * (index * 2 - 1);
        nextSpell.transform.Rotate(Vector3.forward * offAngle);
    }

    void Update() {
        Vector3 pos = transform.position;
        pos += transform.right * Time.deltaTime;
        transform.position = pos;
    }
}
