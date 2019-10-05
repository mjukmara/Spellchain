using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pickup", menuName = "Custom/Pickup", order = 1)]
public class PickupType : ScriptableObject {
    public string label;
    public GameObject spellPrefab;
}