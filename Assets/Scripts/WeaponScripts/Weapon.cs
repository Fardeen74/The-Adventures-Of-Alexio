using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeaponSpr;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public int damage;

    public AudioClip[] shootClips;


    public void Shoot()
    {
        Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);

        SoundManager.instance.PlaySoundFX(shootClips[Random.Range(0, shootClips.Length)]);
    }
    
}

