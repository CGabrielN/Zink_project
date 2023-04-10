using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static HealthController Instance { get; private set; }
    public float Health = 100f;
    public float maxHealth = 100f;
    public Slider healthBar;
    public PostProcessVolume damageVignette;
    private float defaultVigneteIntensity;
    Vignette old_vignette;
    public Text HP;


    void Start()
    {
        Instance = this;
        healthBar = GameObject.FindObjectsOfType<Slider>()[0];
        HP = healthBar.GetComponentInChildren<Text>();
        healthBar.maxValue = maxHealth;
        HP.text = maxHealth.ToString();
        damageVignette.profile.TryGetSettings(out old_vignette);
        defaultVigneteIntensity= old_vignette.intensity.value;
    }

    public void ChangeHealth(float value) {
        Health += value;
        if(value < 0) {
            StartCoroutine(SetDamageEffect());
        }
        if(Health > maxHealth) {
            Health = maxHealth;
        }
        if(Health <= 0) {
            Time.timeScale = 0f; Health = 0;
            GameOverUI.Instance.Display();
        }
        healthBar.value = Health;
        HP.text = Health.ToString();
    }

    public IEnumerator SetDamageEffect() {
        float new_vignette_intensity = 0.5f;
        old_vignette.color.Override(Color.red);
        old_vignette.intensity.value = new_vignette_intensity;
        yield return new WaitForSecondsRealtime(0.5f);
        old_vignette.color.Override(new Color(0.399f,0.027f,0.027f,1));
        old_vignette.intensity.value = defaultVigneteIntensity;

    }
}
