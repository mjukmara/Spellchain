using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpell : Spell {

    public float speed = 5f;
    public float sineAmplitude = 1f;
    public float sineFrequency = 1f;

    private float timePassed = 0;
    private float randomTime;

    public override void Start() {
        base.Start();
        randomTime = Random.Range(0, Mathf.PI * 2);
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    void Update() {
        timePassed += Time.deltaTime;
        float rotate = Mathf.Sin(randomTime + Mathf.PI / 2 + Time.time * sineFrequency) * sineAmplitude;
        transform.Rotate(Vector3.forward * rotate);
        Vector3 pos = transform.position;
        pos += transform.right * speed * Time.deltaTime;
        transform.position = pos;
    }
}
