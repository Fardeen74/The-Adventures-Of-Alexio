using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField]
    private float healthPackValue = 30f;
    //public GameObject obj;

    public AudioClip healthSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(+healthPackValue);
        SoundManager.instance.PlaySoundFX(healthSound);
        Destroy(gameObject);
    }
}
