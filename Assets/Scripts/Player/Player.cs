using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    //public GameObject bullet;
    public float speed = 1f;
    private Animator legAnim;
    public Weapon currentWeapon;
    private Vector2 moveVelocity;

    private float nextTimeFire = 0;
   
  
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        legAnim = transform.GetChild(2).GetComponent<Animator>();
        transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSpr;
    }

    private void Update()
    {
        //Shoot Function
        
        if (Input.GetMouseButton(0))
        {
            if(Time.time >= nextTimeFire)
            {
                currentWeapon.Shoot();
                nextTimeFire = Time.time + 1 / currentWeapon.fireRate;
            }
        }

        Rotation();


    }

    void FixedUpdate()
    {
        Movement();
        
    }

    void Rotation() 
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    
    
    }

    void Movement() 
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput.normalized * speed;

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);


        if (moveVelocity == Vector2.zero)
            legAnim.SetBool("Moving", false);
        else
            legAnim.SetBool("Moving", true);

    }
}
