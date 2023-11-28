using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the character is grounded.
        //isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius, groundLayer);

        // Handle jumping when the player presses a key (e.g., Spacebar).
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
    }

    public void jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
}