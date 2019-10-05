using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public GameObject spellPrefab;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            PlayerSpells playerSpells = col.gameObject.GetComponent<PlayerSpells>();
            if (spellPrefab) {
                playerSpells.AddSpellPrefab(spellPrefab);
            }
            Destroy(gameObject);
        }
    }
}
