using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    float movementX;
    [SerializeField] float speed = 5;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpPower = 50;
    bool jumping = false;
    private int coinScore;
    bool touchingGround;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
    }

    void OnJump()
    {
        if (touchingGround)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumping = true;
        }
    }

    void Update()
    {
        
        animator.SetBool("isWalking", movementX != 0f);

       
        if (movementX != 0)
        {
            spriteRenderer.flipX = movementX < 0f;
        }
    }

    void FixedUpdate()
    {
       
        Vector2 vel = rb.linearVelocity;
        vel.x = movementX * speed;
        rb.linearVelocity = vel;

        if (jumping)
        {
            rb.AddForce(Vector2.up * jumpPower);
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            touchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            touchingGround = false;
        }
    }

    public void AddCoin(int value)
    {
        coinScore += value;
        UnityEngine.Debug.Log(value);
    }
}
