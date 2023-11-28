using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float m_Speed;

    private void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * m_Speed,Space.Self);
    }
}
