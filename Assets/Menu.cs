using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public void LoadGame() {
        var FadeScreen = FindObjectsOfType<FadeScreen>();
        FadeScreen[0].LoadScene("Map");
    }
}
