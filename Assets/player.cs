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
    public Transform groundCheck;
    public float groundCheckRadius = .1f;
    public LayerMask groundLayer;
    private float bunnySize = 1.5f;

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
        // if (Input.GetKey("w") && isGrounded)
        if (Input.GetAxis("Vertical") > 0 && isGrounded)
        {
           
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        //if (Input.GetKey("a"))
           // rb.velocity = new Vector2(-speed, rb.velocity.y);
       
        //else if (Input.GetKey("d"))
          //  rb.velocity = new Vector2(speed, rb.velocity.y);

        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            gameObject.transform.localScale = new Vector3(-bunnySize, bunnySize, 0);

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            gameObject.transform.localScale = new Vector3(bunnySize, bunnySize, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "rock")
        {
            StartCoroutine(PlayerDies());
        }
        else if (collision.gameObject.name == "snake" || collision.gameObject.name == "snake2" ||
            collision.gameObject.name == "snake3")
            StartCoroutine(PlayerDies3());
        else if (collision.gameObject.name == "rock1" || collision.gameObject.name == "rock2"
        || collision.gameObject.name == "rock3" || collision.gameObject.name == "rock4" ||
            collision.gameObject.name == "rock5")
            StartCoroutine(PlayerDies1());
       
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "death")
        {
            StartCoroutine(PlayerDies());
        }
        else if (collision.gameObject.name == "death1")
            StartCoroutine(PlayerDies2());
        else if (collision.gameObject.name == "rabbit")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private IEnumerator PlayerDies()
    {
        transform.position = new Vector3(0, -30, 0);
        //gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        //gameObject.SetActive(true);
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(-6.5f, 7.5f, 0);
    }

    private IEnumerator PlayerDies1()
    //void PlayerDies()
    {
        transform.position = new Vector3(0, -30, 0);
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(-8.1f, .6f, 0);

        // yield return null;
    }

    private IEnumerator PlayerDies2()
    {
        transform.position = new Vector3(0, -30, 0);
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(-7.3f, 1.5f, 0);
    }

    private IEnumerator PlayerDies3()
    {
        //transform.position = new Vector3(0, -30, 0);
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(-8f, 3.3f, 0);
    }

}
