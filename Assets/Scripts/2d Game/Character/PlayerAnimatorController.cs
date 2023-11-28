using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public Animator animator;

    public void SetSpeed(float value)
    {
        animator.SetFloat("Speed", value);
    }

    public void SetArielSpeed(float value)
    {
        animator.SetFloat("AerialSpeed", value);
    }

    public void SetGrounded(bool value)
    {
        animator.SetBool("IsGrounded", value);
    }
}
