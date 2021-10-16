using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxhealth = 100f;
    [SerializeField] private Slider healthSlider;

    public GameObject deathScreen;

    public AudioClip DeathSfx;

    void Start()
    {
        health = maxhealth;
        healthSlider.maxValue = maxhealth;   
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxhealth)
        {
            health = maxhealth;
        }

        else if (health <= 0f)
        {
            health = 0f;
            healthSlider.value = health;
            SoundManager.instance.PlaySoundFX(DeathSfx);
            Playerdied();
        }

    }

    public void Playerdied()
    {
        deathScreen.GetComponent<DeathScreen>().deathScreenUI.SetActive(true);
        Time.timeScale = 0f;

    }

    private void OnGUI()
    {
        float t = Time.deltaTime / 1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
    }
}
