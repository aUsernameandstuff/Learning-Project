using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonController : MonoBehaviour
{
    public float MovementSpeed = 2f;
    
    void Update()
    {
        transform.Translate(transform.up * MovementSpeed);
    }

    private void OnMouseDown()
    {
        FindObjectOfType<GameController>().AddScore(500);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
