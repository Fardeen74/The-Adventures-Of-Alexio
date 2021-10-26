using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float enemyHealth;

    public BoxCollider2D enemyBoxCollider;

    public AudioClip hit;

    public AudioClip enemDeath;

    private void Update()
    {

        if (enemyHealth <= 0)
        {
            SoundManager.instance.PlaySoundFX(enemDeath);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && collision.IsTouching(enemyBoxCollider))
        {
            
            enemyHealth -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage;
            SoundManager.instance.PlaySoundFX(hit);
            Destroy(collision.gameObject);
        }
    }
}