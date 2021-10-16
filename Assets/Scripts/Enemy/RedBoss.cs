using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : MonoBehaviour
{
    [SerializeField]
    public float enemyHealth;

    [SerializeField]
    public float maxEnemyHealth;

    public BoxCollider2D enemyBoxCollider;

    public GameObject subBossprefab;
    public Transform subBossPos1, subBossPos2;

    public AudioClip hit;
    private bool isSpawned;

    private void Start()
    {
        enemyHealth = maxEnemyHealth;
    }

    private void Update()
    {

        if (enemyHealth <= maxEnemyHealth/2)
        {
            if (!isSpawned)
            {
                SpawnSubBoss();
                isSpawned = true;
            }
        }



        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            SoundManager.instance.PlaySoundFX(hit);
        }
    }

    public void SpawnSubBoss()
    {
        Instantiate(subBossprefab, subBossPos1.transform.position, transform.rotation);
        Instantiate(subBossprefab, subBossPos2.transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && collision.IsTouching(enemyBoxCollider))
        {
            // Debug.Log("Hitting box collider");
            enemyHealth -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage;
            Destroy(collision.gameObject);
        }
    }
}

