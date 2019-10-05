using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {
    public float duration = 1.0f;
    public int nextSpellCount = 1;
    public List<GameObject> spellPrefabs;

    public virtual void Start() {
        StartCoroutine(SpawnNextSpell());
    }

    public virtual void OnSpellEnd() {

    }

    public virtual void OnNextSpell(GameObject nextSpell, int index) {

    }

    public void SetSpellPrefabs(List<GameObject> spellPrefabs) {
        this.spellPrefabs = spellPrefabs;
    }
    
    IEnumerator SpawnNextSpell() {
        yield return new WaitForSeconds(duration);

        if (spellPrefabs.Count > 0) {
            for (int i=0; i<nextSpellCount; i++) {
                GameObject go = Instantiate(spellPrefabs[0], transform.position, transform.rotation);
                Spell spell = go.GetComponent<Spell>();

                if (spellPrefabs.Count > 1) {
                    List<GameObject> nextSpellPrefabs = new List<GameObject>(spellPrefabs);
                    nextSpellPrefabs.RemoveAt(0);
                    spell.SetSpellPrefabs(nextSpellPrefabs);
                }
                OnNextSpell(go, i);
            }
        }

        OnSpellEnd();
        Destroy(gameObject);
    }
}
