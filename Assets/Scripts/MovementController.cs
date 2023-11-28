using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float m_MovementSpeed = 0.5f;

    public Animator animator;

    void Update()
    {
        //Legacy Method
        // m_Transform.Translate(Input.GetAxis("Horizontal") * m_MovementSpeed, 0,
        //   Input.GetAxis("Vertical") * m_MovementSpeed);

        float horrizontalInput = Input.GetAxis("Horizontal");
        
        Vector3 input = new Vector3(0, 0, Input.GetAxis("Vertical"));
        transform.Translate(input * m_MovementSpeed);

        transform.Rotate(0, horrizontalInput, 0);
        animator.SetFloat("Speed", Input.GetAxis("Vertical"));
    }
}
