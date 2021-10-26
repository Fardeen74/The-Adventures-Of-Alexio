using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;
    [SerializeField] private float maxhealth = 100f;
    [SerializeField] private Slider healthSlider;

    public AudioClip DeathSfx;

    public GameObject deathScreenUI;

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
            PlayerDied();
        }

    }

    public void PlayerDied()
    {
        Debug.Log("Player Dead");
        deathScreenUI.SetActive(true);
        GameManager.instance.isOtherUIActive = true;
        Time.timeScale = 0f;
    }

    private void OnGUI()
    {
        float t = Time.deltaTime / 1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
    }
}
