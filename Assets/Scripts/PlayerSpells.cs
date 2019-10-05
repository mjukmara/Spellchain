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

            Vector3 mouse = Input.mousePosition;
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 offset = new Vector3(mouse.x - screenPoint.x, mouse.y - screenPoint.y, 0);
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

            if (spellPrefabs.Count > 0) {

                Vector3 instantiatePos = transform.position + offset.normalized * 0.5f;

                GameObject go = Instantiate(spellPrefabs[0], instantiatePos, Quaternion.Euler(0, 0, angle));
                Spell spell = go.GetComponent<Spell>();

                if (spellPrefabs.Count > 1) {
                    List<GameObject> nextSpellPrefabs = new List<GameObject>(spellPrefabs);
                    nextSpellPrefabs.RemoveAt(0);
                    spell.SetSpellPrefabs(nextSpellPrefabs);
                }
            }
        }
    }

    public void AddSpellPrefab(GameObject spellPrefab) {
        spellPrefabs.Add(spellPrefab);
    }
}
