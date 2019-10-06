using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {

    public PickupType pickupType;
    public Text text;

    void Start() {
        text.text = pickupType.label;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            PlayerSpells playerSpells = col.gameObject.GetComponent<PlayerSpells>();
            if (pickupType.spellPrefab) {
                playerSpells.AddSpellPrefab(pickupType.spellPrefab);
            }
            AudioManager.PlaySfx("Powerup");
            Destroy(gameObject);
        }
    }
}
