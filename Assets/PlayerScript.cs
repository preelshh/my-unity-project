using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    float movementX;
    [SerializeField] float speed = 5;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpPower = 50;
    bool jumping = false;
    bool touchingGround;

    // ✅ New: Reference to the Animator
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();   // get the Animator component on the same object
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        Debug.Log(v);
    }

    void OnJump()
    {
        if (touchingGround)
        {
            jumping = true;
        }
    }

    void FixedUpdate()
    {
        // Horizontal movement
        Vector2 vel = rb.linearVelocity;
        vel.x = movementX * speed;
        rb.linearVelocity = vel;

        // ✅ New: Update Animator parameter based on movement
        animator.SetBool("isWalking", movementX != 0);

        // Jumping
        if (jumping)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumping = false; // ensure it only fires once per jump
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
}
