using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineSpell : Spell {

    public float sineSquish = 1f;
    public float sineSpeed = 1f;

    private float timePassed = 0;

    void Update() {
        timePassed += Time.deltaTime;
        float rotate = Mathf.Sin(Mathf.PI / 2 + Time.time * sineSpeed) * sineSquish;
        transform.Rotate(Vector3.forward * rotate);
        Vector3 pos = transform.position;
        pos += transform.right * Time.deltaTime;
        transform.position = pos;
    }

    public override void OnNextSpell(GameObject spell, int index) {

    }
}
