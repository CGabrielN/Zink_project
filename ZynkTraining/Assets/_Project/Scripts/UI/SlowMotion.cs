using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    private bool slowMotion = false;

    private void Start() {
        //DontDestroyOnLoad(this.gameObject);
        if (PlayerPrefs.HasKey("Slow Motion")) {
            if (PlayerPrefs.GetString("Slow Motion") == "True") {
                slowMotion = true;
                SettingsUI.Instance.SlowMotionStatus.text = "ON";
            } else if (PlayerPrefs.GetString("Slow Motion") == "False") {
                slowMotion = false;
                SettingsUI.Instance.SlowMotionStatus.text = "OFF";
            }
        }
    }

    public void ToggleSlowMotion() {
        if (slowMotion) {
            slowMotion = false;
            PlayerPrefs.SetString("Slow Motion", "False");
            SettingsUI.Instance.SlowMotionStatus.text = "OFF";
        } else {
            slowMotion = true;
            PlayerPrefs.SetString("Slow Motion", "True");
            SettingsUI.Instance.SlowMotionStatus.text = "ON";
        }
    }
    
}
