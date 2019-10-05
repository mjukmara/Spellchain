using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellStack {

    public List<GameObject> spellPrefabs = new List<GameObject>();

    public SpellStack() {

    }

    public SpellStack(List<GameObject> spellPrefabs) {
        spellPrefabs.AddRange(spellPrefabs);
    }

    public void AddSpellPrefab(GameObject spellPrefab) {
        spellPrefabs.Add(spellPrefab);
    }
}
