using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource audioSource;
    public Clip[] clips;

    Dictionary<string, Clip> lookup = new Dictionary<string, Clip>();

    void Start() {
        foreach (Clip clip in clips) {
            lookup.Add(clip.name, clip);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            PlaySfx("Hit");
        }
    }

    public void Play(string name) {
        Clip clip;
        lookup.TryGetValue(name, out clip);
        if (clip != null) {
            audioSource.PlayOneShot(clip.clip, clip.volume);
        }
    }

    [System.Serializable]
    public class Clip {
        public string name;
        public AudioClip clip;
        public float volume = 1f;
    }

    public static void PlaySfx(string name) {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play(name);
    }
}
