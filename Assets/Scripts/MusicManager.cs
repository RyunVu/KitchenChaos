using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{

    private const string PLAYERS_PREFS_MUSIC_VOLUME = "MusicVolume";

    public static MusicManager Instance { get; private set; } 

    private AudioSource audioSource;

    private float volume = .5f;

    private void Awake() {
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        volume = PlayerPrefs.GetFloat(PLAYERS_PREFS_MUSIC_VOLUME, .5f);
        audioSource.volume = volume;

    }

    public void ChangeVolume() {
        volume += .1f;

        if (volume > 1.01f) {
            volume = 0f;
        }
        audioSource.volume = volume;

        PlayerPrefs.SetFloat(PLAYERS_PREFS_MUSIC_VOLUME, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume() { return volume; }

}
