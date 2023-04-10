using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance { get; private set; }

    private float volumeD = 1f;
    private void Start() {
        Instance = this;
        //DontDestroyOnLoad(this.gameObject);
        if (PlayerPrefs.HasKey("MusicVolume")) {
            volumeD = PlayerPrefs.GetFloat("MusicVolume");      
        }
        ToggleMusic(volumeD * 100);
    }

    public void ToggleMusic(float volume) {
        AudioListener.volume = volume * 1/100f;
        PlayerPrefs.SetFloat("MusicVolume", volume* 1/100f);
        SettingsUI.Instance.soundSlider.value = volume;
        SettingsUI.Instance.soundProcentText.text = volume.ToString() + "%";
    }
}
