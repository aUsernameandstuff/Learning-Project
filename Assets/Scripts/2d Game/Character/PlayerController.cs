using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D characterrigidbody;
    public PlayerAnimatorController playerAnimatorController;

    public float Speed = 15;
    public float JumpValue;

    public float JumpHeight = 0.5f;

    public float heightToAttain;
    public bool isJumping;

    private void Start()
    {
        characterrigidbody ??= GetComponent<Rigidbody2D>();
        playerAnimatorController ??= GetComponent<PlayerAnimatorController>();

        Application.targetFrameRate = 60;
    }

    // v = s/t

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        float speed = xInput * Speed;
        characterrigidbody.velocity = Vector2.right * speed * Time.deltaTime;

        playerAnimatorController.SetSpeed(Mathf.Abs(speed));

        if (isJumping)
        {
            characterrigidbody.velocity += Vector2.up.normalized * JumpValue * Time.deltaTime;
            CheckJumpHeight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                CharacterJump();
            }
        }
    }

    private void CharacterJump()
    {
        heightToAttain = transform.position.y + JumpHeight;
        isJumping = true;
        playerAnimatorController.SetArielSpeed(1f);
        playerAnimatorController.SetGrounded(false);
    }

    private void CheckJumpHeight()
    {
        if (transform.position.y >= heightToAttain)
        {
            isJumping = false;
            playerAnimatorController.SetArielSpeed(-1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Ground"))
        {
            playerAnimatorController.SetGrounded(true);
        }
    }
}
