using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {
    public float duration = 1.0f;
    public List<GameObject> nextSpellPrefabs;

    void Start() {
        StartCoroutine(SpawnNextSpell());
    }

    IEnumerator SpawnNextSpell() {
        yield return new WaitForSeconds(duration);
        for (int i = 0; i < nextSpellPrefabs.Count; i++) {
            GameObject nextSpellPrefab = nextSpellPrefabs[i];
            GameObject nextSpell = Instantiate(nextSpellPrefab, transform.position, transform.rotation);
            nextSpell.name = nextSpellPrefab.name;
            OnNextSpell(nextSpell, i);
        }
        Destroy(gameObject);
    }

    public virtual void OnNextSpell(GameObject spell, int index) {

    }
}
