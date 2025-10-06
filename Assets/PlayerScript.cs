using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    float movementX;
    float movementY;
    [SerializeField] float speed = 6;
    [SerializeField] Rigidbody2D rb;

     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;

        Debug.Log(v);
    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed * Time.fixedDeltaTime;
        float YmoveDistance = movementY * speed * Time.fixedDeltaTime;
        transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
       // rb.linearVelocity = new Vector2(XmoveDistance, YmoveDistance);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggeExit2D(Collider2D collision)
    {

    }
    
  
}
