using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // amber
    //float speed = 0.07f;
    float speed = 5f;
    float jumpSpeed = 20f;
    public Rigidbody2D rb;
    public float m_Thrust = 20f;
    Vector2 force = new Vector2(5.0f, 35.0f);
    Vector2 extraForce = new Vector2(30.0f, 35.0f);
    Vector2 extraForceBack = new Vector2(-30.0f, 35.0f);
    public CircleCollider2D circleCollider;
    bool isGrounded;
    bool jumped = false;
    public Transform groundCheck;
    public float groundCheckRadius = .1f;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        circleCollider.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetKey("w") && isGrounded)
        {
            jumped = true;
            //if (Input.GetKey("d"))
            //  rb.AddForce(extraForce, ForceMode2D.Impulse);
            //else if (Input.GetKey("a"))
            //  rb.AddForce(extraForceBack, ForceMode2D.Impulse);
            //else
            //  rb.AddForce(force, ForceMode2D.Impulse);
            //isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        //if (Input.GetKey("w") && jumped)
        //{
        //    rb.AddForce(force, ForceMode2D.Impulse);
        //    jumped = false;
        //}

        //transform.Translate(0, speed, 0);


        //if (Input.GetKey("s"))
        //  transform.Translate(0, -speed, 0);
        if (Input.GetKey("a"))
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        //transform.Translate(-speed, 0, 0);
        else if (Input.GetKey("d"))
            rb.velocity = new Vector2(speed, rb.velocity.y);
            ///transform.Translate(speed, 0, 0);
    }


}
