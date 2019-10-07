using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour {

    public GameObject PickUpEffect;
    public Transform ThisObject;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            AudioManager.PlaySfx("Powerup");
            Instantiate(PickUpEffect, ThisObject.position, ThisObject.rotation);
            Player player = collider.gameObject.GetComponent<Player>();
            player.healthBar.hp = player.healthBar.maxHp;
            player.healthBar.UpdateGreenBar();
            Destroy(gameObject);
        }
    }
}
