using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float enemyHealth;

    public BoxCollider2D enemyBoxCollider;

    public AudioClip hit;

    private void Update()
    {

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            SoundManager.instance.PlaySoundFX(hit);
        }
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