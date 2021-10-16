using System.Collections;
using UnityEngine;

public class RobotEnemy : MonoBehaviour
{
    private Transform playerPos;
    private Rigidbody2D rb;
    public float speed = .3f;

    public Transform bulletPos1, bulletPos2;
    public GameObject bullet;

    private bool isInRange = false;

    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 5f;
    private float canAttack;

    public AudioClip DamageClip;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > 2.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            isInRange = false;
        }
        else
        {
            isInRange = true;
        }
    }

    private void FixedUpdate()
    {
        Rotation();
    }

    private void Rotation()
    {
        Vector2 dir = (playerPos.gameObject.GetComponent<Rigidbody2D>().position - rb.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angle;
    }

    private IEnumerator Shoot()
    {
        if (isInRange)
        {
            Instantiate(bullet, bulletPos1.position, transform.rotation);
        }
        yield return new WaitForSeconds(.4f);
        if (isInRange)
        {
            Instantiate(bullet, bulletPos2.position, transform.rotation);
        }
        yield return new WaitForSeconds(.4f);
        StartCoroutine(Shoot());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                SoundManager.instance.PlaySoundFX(DamageClip);
                canAttack = 0f;
            }
            else canAttack += Time.deltaTime;

        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                SoundManager.instance.PlaySoundFX(DamageClip);
                canAttack = 0f;
            }
            else canAttack += Time.deltaTime;

        }
    }

}