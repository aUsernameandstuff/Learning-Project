using UnityEngine;

public class Jump : MonoBehaviour
{   
    public PlayerAnimatorController playerAnimatorController;
    
    public float JumpForce;
    public float JumpHeight = 0.5f;
    public float heightToAttain;
    
    public bool canPlayerJumping = true;

    public Rigidbody2D rb;
    
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!canPlayerJumping)
            return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            heightToAttain = transform.position.y + JumpHeight;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.LogError("Jump");
            rb.velocity += Vector2.up.normalized * JumpForce * Time.deltaTime;
            playerAnimatorController.SetArielSpeed(1f);
            playerAnimatorController.SetGrounded(false);
            
            CheckJumpHeight();
        }
    }

    private void CharacterJump()
    {
        playerAnimatorController.SetGrounded(false);
        playerAnimatorController.SetArielSpeed(1f);
    }

    private void CheckJumpHeight()
    {
        if (transform.position.y >= heightToAttain)
        {
            canPlayerJumping = false;
            playerAnimatorController.SetArielSpeed(-1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Ground"))
        {
            playerAnimatorController.SetGrounded(true);
            playerAnimatorController.SetArielSpeed(0f);
            canPlayerJumping = true;
        }
    }
}