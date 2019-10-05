using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{

    public List<GameObject> spellPrefabs;

    void Start() {

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (spellPrefabs.Count > 0) {
                GameObject go = Instantiate(spellPrefabs[0], transform.position, Quaternion.identity);
                Spell spell = go.GetComponent<Spell>();

                if (spellPrefabs.Count > 1) {
                    List<GameObject> nextSpellPrefabs = new List<GameObject>(spellPrefabs);
                    nextSpellPrefabs.RemoveAt(0);
                    spell.SetSpellPrefabs(nextSpellPrefabs);
                }
            }
        }
    }
}
