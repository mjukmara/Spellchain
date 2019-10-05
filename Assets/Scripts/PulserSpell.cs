using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulserSpell : Spell
{
    // Start is called before the first frame update
    public override void Start() {
        base.Start();

        StartCoroutine(Pulse());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Pulse() {
        InstantiateNextSpell(15);
        yield return new WaitForSeconds(0.2f);
        InstantiateNextSpell(15);
        yield return new WaitForSeconds(0.1f);
        InstantiateNextSpell(15);
    }
}
