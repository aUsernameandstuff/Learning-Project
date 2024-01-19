using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D characterrigidbody;
    public PlayerAnimatorController playerAnimatorController;

    public LayerMask groundLayers;
    public float CheckGroundDistance = 1.5f;
    public float Sprint = 0;
    public float Speed = 15;
    public float JumpValue;

    public float JumpHeight = 0.5f;

    public float heightToAttain;
    public bool isJumping;
    public bool isGrounded = true;
    public bool CheckSprint = false;
    public bool canJump = true;
    
    private void Start()
    {
        characterrigidbody ??= GetComponent<Rigidbody2D>();
        playerAnimatorController ??= GetComponent<PlayerAnimatorController>();

        Application.targetFrameRate = 60;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.up * CheckGroundDistance);
    }

    // v = s/t

    private void FixedUpdate()
    {
        CheckIfPlayerIsGrounded();
        SprintInput();
        PlayerMovement();
        
        if (!canJump)
            return;

        CalculateJumpHeight();
        JumpInput();
    }

    private void CheckIfPlayerIsGrounded()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, CheckGroundDistance, groundLayers))
        {
            isGrounded = true;
            playerAnimatorController.SetArielSpeed(0f);
        }
        else
        {
            isGrounded = false;

            if (characterrigidbody.velocity.y > 0)
            {
                playerAnimatorController.SetArielSpeed(-1f);   
            }
            else
            {
                playerAnimatorController.SetArielSpeed(1f);
            }
        }
        
        playerAnimatorController.SetGrounded(isGrounded);
    }

   private void SprintInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint = 80 * Input.GetAxis("Horizontal");
            CheckSprint = true;
        }
        else
        {
            Sprint = 0;
            CheckSprint = false;
        }
    }
   
    private void JumpInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.LogError("Jump");
            characterrigidbody.velocity += Vector2.up.normalized * JumpValue * Time.deltaTime;
            CheckJumpHeight();
        }
    }
    
    private void CalculateJumpHeight()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            heightToAttain = transform.position.y + JumpHeight;
        }
    }

    private void PlayerMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float speed = xInput * Speed + Sprint;

        characterrigidbody.velocity = Vector2.right * speed * Time.deltaTime;
        playerAnimatorController.SetSpeed(Mathf.Abs(speed));
    }

    private void CharacterJump()
    {
        heightToAttain = transform.position.y + JumpHeight;
        isJumping = true;
    }

    private void CheckJumpHeight()
    {
        if (transform.position.y >= heightToAttain)
        {
            isJumping = false;
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Ground"))
        {
            canJump = true;
        }

        if (col.transform.GetComponent<SpikeFloor>())
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Debug.LogError("Player Die Method");
    }
}
