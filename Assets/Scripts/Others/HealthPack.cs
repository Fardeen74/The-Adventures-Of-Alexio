using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField]
    private float healthPackValue = 30f;

   
    public AudioClip healthSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().UpdateHealth(+healthPackValue);
            SoundManager.instance.PlaySoundFX(healthSound);
            Destroy(gameObject);
        }
        
    }
}
