using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 5f;
    private float canAttack;
    //public Rigidbody2D PlayerRB;
    private Transform target;

    public AudioClip DamageClip;


    

    private void FixedUpdate()
    {
        if(target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.transform;
            //canFollow = false;
        }

        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = null;
        }
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




