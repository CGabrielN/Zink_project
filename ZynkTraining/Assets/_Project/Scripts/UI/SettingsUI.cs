using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

public class SettingsUI : MonoBehaviour
{
    public static SettingsUI Instance { get; private set; }
    public Button SoundButton;
    public Button BackButton;
    public Button SlowMotionButton;
    public MusicPlayer Player;
    public SlowMotion slowMotion;
    public Slider soundSlider;
    public bool musicOn = true;
    public Text soundProcentText;
    public Text SlowMotionStatus;
    
    
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Init() {
        BackButton.onClick.AddListener(() => { Instance.BackToPause(); });
        SoundButton.onClick.AddListener(() => { Instance.MuteSound(); });
        SlowMotionButton.onClick.AddListener(() => { Instance.EnableSlowMotion(); });
        soundSlider.onValueChanged.AddListener((float volume) => { Instance.ChangeMusicSetting(soundSlider.value); });
    }


    void BackToPause()
    {
        UIAudioPlayer.PlayNegative();
        gameObject.SetActive(false);
        PauseMenu.Instance.Display();
        Controller.Instance.CanPause = true;
    }

    void EnableSlowMotion() {
        UIAudioPlayer.PlayPositive();
        slowMotion.ToggleSlowMotion();
    }

    void MuteSound() {
        UIAudioPlayer.PlayPositive();
        Player.ToggleMusic(musicOn==true?0:100);
        musicOn = !musicOn;
    }

    void ChangeMusicSetting(float volume) {
        Player.ToggleMusic(volume);
    }

    public void DisplaySettings() {
        Controller.Instance.CanPause = false;
        BackButton.onClick.RemoveAllListeners();
        BackButton.onClick.AddListener(BackToPause);
        gameObject.SetActive(true);
    }

    
}
