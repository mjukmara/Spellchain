using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeCollider : MonoBehaviour {
    public EnemyMovement enemyMovement;

    void OnTriggerExit2D(Collider2D collider) {
        enemyMovement.direction *= -1;
    }
}
