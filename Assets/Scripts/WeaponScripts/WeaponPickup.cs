using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon;

    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player") 
        {
            target.GetComponent<Player>().currentWeapon = weapon;
            target.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSpr;
            Destroy(gameObject);
        }
        
    }
}
