using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBulletMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    [SerializeField]
    private  float bulletDamage = 10f;

    public AudioClip RobotBulletSfx;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = transform.up * -speed;
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-bulletDamage);
            SoundManager.instance.PlaySoundFX(RobotBulletSfx);
            Destroy(gameObject);
        }
    }
}
